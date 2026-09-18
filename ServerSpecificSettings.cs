using System;
using System.Collections.Generic;
using System.Linq;
using Exiled.API.Features.Core.UserSettings;
using Exiled.Events.EventArgs.Player;
using Hints;
using UnityEngine;
using GamePlayer = Exiled.API.Features.Player;

namespace SCP294
{
    public partial class SCP294
    {
        public const int UseSettingId = 294010;
        public const int DrinkSettingId = 294011;
        private readonly Dictionary<GamePlayer, float> keyCooldowns = new Dictionary<GamePlayer, float>();
        private SettingBase[] machineSettings = Array.Empty<SettingBase>();
        private readonly Commands.SCP294Command keyCommand = new Commands.SCP294Command();

        private void RegisterMachineSettings()
        {
            // Append our settings; never replace another plugin's Server Specific menu.
            var header = new HeaderSetting(294009, "SCP-294", "Hold a coin near the machine. Choose a drink and press your configured key.");
            machineSettings = SettingBase.Register(new SettingBase[]
            {
                new KeybindSetting(UseSettingId, "Use SCP-294", KeyCode.K,
                    preventInteractionOnGUI: true, allowSpectatorTrigger: false,
                    hintDescription: "Dispense your chosen drink while holding a coin near SCP-294.",
                    collectionId: byte.MaxValue, header: header, onChanged: OnMachineKey),
                new UserTextInputSetting(DrinkSettingId, "Drink order", "random", 64,
                    hintDescription: "For example: coffee, water, or random. Empty means random.", header: header),
            }).ToArray();
            Exiled.Events.Handlers.Player.Verified += SendMachineSettings;
            Exiled.Events.Handlers.Player.Left += ForgetMachinePlayer;
            Exiled.Events.Handlers.Server.RestartingRound += ClearMachineKeyCooldowns;
        }

        private void UnregisterMachineSettings()
        {
            Exiled.Events.Handlers.Player.Verified -= SendMachineSettings;
            Exiled.Events.Handlers.Player.Left -= ForgetMachinePlayer;
            Exiled.Events.Handlers.Server.RestartingRound -= ClearMachineKeyCooldowns;
            if (machineSettings.Length > 0)
            {
                SettingBase.Unregister(settings: machineSettings);
                // EXILED 9.14.2 unsyncs definitions but keeps its callback cache.
                // Remove only our own instances so a plugin reload cannot retain stale callbacks.
                if (SettingBase.List is ICollection<SettingBase> definitions)
                    foreach (var setting in machineSettings) definitions.Remove(setting);
                machineSettings = Array.Empty<SettingBase>();
            }
            ClearMachineKeyCooldowns();
        }

        private void SendMachineSettings(VerifiedEventArgs ev) => SettingBase.SendToPlayer(ev.Player);
        private void ForgetMachinePlayer(LeftEventArgs ev) => keyCooldowns.Remove(ev.Player);
        private void ClearMachineKeyCooldowns() => keyCooldowns.Clear();

        private void OnMachineKey(GamePlayer player, SettingBase setting)
        {
            if (Instance != this || !(setting is KeybindSetting key) || !key.IsPressed ||
                player == null || !player.IsConnected || !player.IsAlive || player.IsNPC) return;
            float now = Time.realtimeSinceStartup;
            if (keyCooldowns.TryGetValue(player, out float until) && now < until) return;
            keyCooldowns[player] = now + .75f;
            string order = SettingBase.TryGetSetting<UserTextInputSetting>(player, DrinkSettingId, out var input) ? input.Text : "";
            order = string.IsNullOrWhiteSpace(order) ? "random" : order.Trim();
            if (order.Length > 64) order = order.Substring(0, 64);
            // The key and console deliberately use the exact same validation and dispensing path.
            keyCommand.Execute(new ArraySegment<string>(order.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)),
                player.Sender, out string response);
            player.ShowHint(response.Replace("<", "").Replace(">", ""), 3f);
        }
    }
}
