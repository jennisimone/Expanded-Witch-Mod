using HarmonyLib;
using StardewModdingAPI;
using StardewValley;
using StardewValley.Events;

namespace WitchEventsShop {
    [HarmonyPatch]
    internal sealed class WitchEventRemover : Mod {
        public static void Utility_pickFarmEvent_Postfix(ref FarmEvent __result) {
            if (!Game1.player.eventsSeen.Contains(16304001) && __result is WitchEvent) {
                __result = null;
            }
        }
        
        public override void Entry(IModHelper helper) {
            var harmony = new Harmony(ModManifest.UniqueID);

            harmony.Patch(
                original: AccessTools.Method(typeof(Utility), nameof(Utility.pickFarmEvent)),
                postfix: new HarmonyMethod(typeof(WitchEventRemover), nameof(Utility_pickFarmEvent_Postfix))
            );
        }
    }
}