using ProjectMER.Features.Objects;
using SCP294.Classes;
using SCP294.Types;
using System.Collections.Generic;
using System.Linq;
using VoiceChat.Codec;

namespace SCP294.handlers
{
    public class serverHandler
    {
        public void Cleanup()
        {
            SoundHandler.StopAudio();
            foreach (var obj in SCP294.Instance.SpawnedSCP294s.Keys.ToArray())
                if (obj != null) SCP294Object.RemoveSCP294(obj);
            foreach (var encoder in SCP294.Instance.Encoders.Values.ToArray())
                if (encoder != null) UnityEngine.Object.Destroy(encoder);
            SCP294.Instance.SpawnedSCP294s.Clear();
            SCP294.Instance.SCP294UsesLeft.Clear();
            SCP294.Instance.SCP294LightSources.Clear();
            SCP294.Instance.Encoders.Clear();
            SCP294.Instance.CustomDrinkItems.Clear();
            SCP294.Instance.PlayerVoicePitch.Clear();
            SCP294.Instance.PlayersNear294.Clear();
        }
        public void WaitingForPlayers() {
            Cleanup();
            SCP294.Instance.SpawnedSCP294s = new Dictionary<SchematicObject, bool>();
            SCP294.Instance.PlayersNear294 = new List<string>();
            SCP294.Instance.CustomDrinkItems = new Dictionary<ushort, DrinkInfo>();
            SCP294.Instance.PlayerVoicePitch = new Dictionary<string, float>();
            SCP294.Instance.Encoders = new Dictionary<ReferenceHub, OpusComponent>();
            SCP294Object.SpawnSCP294();
        }
    }
}
