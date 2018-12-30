using System;
using System.Reflection;
using BattleTech;
using BattleTech.UI;
using Harmony;
using Newtonsoft.Json;
using UnityEngine;

namespace HideCareerModeDays
{
    [HarmonyPatch(typeof(SGHeaderWidget), "RefreshCountdown")]
    public static class SGHeaderWidget_RefreshCountdown_Patch
    {
        public static void Postfix(SGHeaderWidget __instance)
        {
            var simGame = Traverse.Create(__instance).Field("simState").GetValue<SimGameState>();
            var careerModeArea = Traverse.Create(__instance).Field("careerModeArea").GetValue<GameObject>();

            if (simGame.IsCareerMode() && (Patches.Settings.HideAlways || simGame.GetCareerModeDaysRemaining() < 0))
            {
                careerModeArea.SetActive(false);
            }
        }
    }

    public class ModSettings
    {
        public bool HideAlways = false;
    }

    public static class Patches
    {
        public static ModSettings Settings;

        public static void Init(string modDir, string modSettings)
        {
            var harmony = HarmonyInstance.Create("io.github.mpstark.HideCareerModeDays");
            harmony.PatchAll(Assembly.GetExecutingAssembly());

            // read settings
            try
            {
                Settings = JsonConvert.DeserializeObject<ModSettings>(modSettings);
            }
            catch (Exception)
            {
                Settings = new ModSettings();
            }
        }
    }
}