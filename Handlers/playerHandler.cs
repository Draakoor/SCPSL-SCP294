using CustomPlayerEffects;
using Exiled.API.Enums;
using Exiled.Events.EventArgs.Player;
using Hazards;
using MEC;
using Mirror;
using PlayerRoles;
using PlayerRoles.PlayableScps.Scp173;
using RelativePositioning;
using SCP294.Types;
using SCP294.Classes;
using SCP294.Types.Config;
using System;
using UnityEngine;

namespace SCP294.handlers
{
    public class playerHandler
    {
        public void VoiceChatting(VoiceChattingEventArgs ev)
        {
            if (!ev.IsAllowed || !SCP294.Instance.Config.EnableVoiceEffects || ev.Player == null) return;
            if (!SCP294.Instance.PlayerVoicePitch.TryGetValue(ev.Player.UserId, out var pitch) || Math.Abs(pitch - 1f) < 0.01f) return;
            var msg = ev.VoiceMessage;
            var comp = OpusComponent.Get(ev.Player.ReferenceHub);
            var samples = new float[5760];
            var count = comp.Decoder.Decode(msg.Data, msg.DataLength, samples);
            if (count <= 0) return;
            comp.PitchShift(Mathf.Clamp(pitch, 0.5f, 2f), count, 48000, samples);
            msg.DataLength = comp.Encoder.Encode(samples, msg.Data, count);
            ev.VoiceMessage = msg;
        }

        public void Joined(JoinedEventArgs args)
        {

        }

        public void ChangingItem(ChangingItemEventArgs args) {
            if (args.Player == null) return;
            if (args.Item == null) return;
            if (args.Player.IsNPC) return;

            if (SCP294.Instance.CustomDrinkItems.TryGetValue(args.Item.Serial, out DrinkInfo drinkInfo))
            {
                args.Player.ShowHint($"You pulled out the Drink of {drinkInfo.DrinkName}", 3);
            }
        }

        public void UsedItem(UsedItemEventArgs args)
        {
            if (args.Player == null) return;
            if (args.Item == null) return;
            if (args.Player.IsNPC) return;

            if (SCP294.Instance.CustomDrinkItems.TryGetValue(args.Item.Serial, out DrinkInfo drinkInfo))
            {
                if (args.Player.IsScp)
                {
                    Timing.CallDelayed(0.01f, () =>
                    {
                        PlayerEffectsController controller = args.Player.ReferenceHub.playerEffectsController;
                        if (args.Player.TryGetEffect(args.Item.Type == ItemType.AntiSCP207 ? EffectType.AntiScp207 : EffectType.Scp207, out StatusEffectBase statusEffect))
                        {
                            byte newValue = (byte)Mathf.Min(255, statusEffect.Intensity - 1);
                            controller.ChangeState(statusEffect.GetType().Name, newValue, 0, false);
                        }
                    });
                }

                // Run any Callbacks
                if (drinkInfo.DrinkCallback != null) drinkInfo.DrinkCallback(args.Player);

                // Show the Message for Drinking
                args.Player.ShowHint(drinkInfo.DrinkMessage, 5);

                args.Player.CurrentItem = null;

                if (drinkInfo.KillPlayer)
                {
                    DrinkCallbacks.DrinkKill(args.Player, drinkInfo);
                } else
                {
                    args.Player.Heal(drinkInfo.HealAmount);
                    // Give player effects from drink
                    PlayerEffectsController controller = args.Player.ReferenceHub.playerEffectsController;
                    if (drinkInfo.HealStatusEffects)
                    {
                        foreach (EffectType effect in Enum.GetValues(typeof(EffectType)))
                        {
                            if (args.Player.TryGetEffect(effect, out StatusEffectBase statusEffect))
                            {
                                byte newValue = (byte)Mathf.Min(255, 0);
                                controller.ChangeState(statusEffect.GetType().Name, newValue, 0, false);
                            }
                        }
                    }
                    foreach (DrinkEffect effect in drinkInfo.DrinkEffects)
                    {
                        if (args.Player.TryGetEffect(effect.EffectType, out StatusEffectBase statusEffect))
                        {
                            byte newValue = (byte)Mathf.Min(255, statusEffect.Intensity + effect.EffectAmount);
                            controller.ChangeState(statusEffect.GetType().Name, newValue, effect.Time, effect.ShouldAddIfPresent);
                        }
                    }
                }
                 
                // Spawn Tantrum when player Drink Funny
                if (drinkInfo.Tantrum)
                {
                    args.Player.PlaceTantrum();
                }

                SCP294.Instance.CustomDrinkItems.Remove(args.Item.Serial);
            }
        }
    }
}

