using BattleTech;
using BattleTech.UI;
using Harmony;
using UnityEngine;

// ReSharper disable InconsistentNaming
// ReSharper disable UnusedMember.Global

namespace HideCareerModeDays.Patches
{
    [HarmonyPatch(typeof(SGHeaderWidget), "RefreshCountdown")]
    public static class SGHeaderWidget_RefreshCountdown_Patch
    {
        public static void Postfix(SGHeaderWidget __instance)
        {
            var simGame = Traverse.Create(__instance).Field("simState").GetValue<SimGameState>();
            var careerModeArea = Traverse.Create(__instance).Field("careerModeArea").GetValue<GameObject>();

            if (simGame.IsCareerMode() && (Main.Settings.HideAlways || simGame.GetCareerModeDaysRemaining() <= 0))
                careerModeArea.SetActive(false);
        }
    }
}
