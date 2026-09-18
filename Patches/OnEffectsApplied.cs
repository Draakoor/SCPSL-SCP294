using HarmonyLib;
using InventorySystem.Items.Usables;
using SCP294.Types;
namespace SCP294.Patches
{
 // Skip only vanilla cola effects for tracked SCP-294 drinks.
 [HarmonyPatch(typeof(Scp207), "OnEffectsActivated")]
 internal static class SCP207OnEffectsActivated
 { private static bool Prefix(Scp207 __instance) => !DrinkInfo.IsCustomDrink(__instance); }
 [HarmonyPatch(typeof(AntiScp207), "OnEffectsActivated")]
 internal static class AntiSCP207OnEffectsActivated
 { private static bool Prefix(AntiScp207 __instance) => !DrinkInfo.IsCustomDrink(__instance); }
}
