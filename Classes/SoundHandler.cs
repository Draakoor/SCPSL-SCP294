using System;
using System.Collections.Generic;
using System.IO;
using Exiled.API.Features;
using UnityEngine;
namespace SCP294
{
 public static class SoundHandler
 {
  private static readonly List<AudioPlayer> Players = new List<AudioPlayer>();
  private static readonly HashSet<string> Loaded = new HashSet<string>();
  public static void PlayAudio(string audioFile, byte volume, bool loop, string soundName, Vector3 position, float dur = 0)
  {
   try
   {
    var clip = "technikbudde.294." + Path.GetFileNameWithoutExtension(audioFile);
    if (!Loaded.Contains(clip))
    {
     var file = Path.Combine(Paths.Configs, "SCP294", Path.GetFileName(audioFile));
     if (!File.Exists(file)) { Log.Warn("SCP-294 audio file missing: " + Path.GetFileName(audioFile)); return; }
     AudioClipStorage.LoadClip(file, clip); Loaded.Add(clip);
    }
    Players.RemoveAll(p => p == null);
    var player = AudioPlayer.Create("technikbudde.294." + Guid.NewGuid().ToString("N"), destroyWhenAllClipsPlayed: !loop);
    player.AddSpeaker("Machine", position, volume: Mathf.Clamp01(volume / 100f), isSpatial: true, minDistance: 2f, maxDistance: 12f);
    player.AddClip(clip, loop: loop); Players.Add(player);
   }
   catch (Exception ex) { Log.Error("SCP-294 audio failed: " + ex.Message); }
  }
  public static void StopAudio()
  {
   foreach (var player in Players) if (player != null) player.Destroy();
   Players.Clear();
  }
 }
}
