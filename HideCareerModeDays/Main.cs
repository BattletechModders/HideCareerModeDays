using System.Reflection;
using Harmony;

// ReSharper disable UnusedMember.Global

namespace HideCareerModeDays
{
    public static class Main
    {
        public static ModSettings Settings;

        public static void Init(string modDir, string modSettings)
        {
            var harmony = HarmonyInstance.Create("io.github.mpstark.HideCareerModeDays");
            harmony.PatchAll(Assembly.GetExecutingAssembly());
            Settings = ModSettings.ReadSettings(modSettings);
        }
    }
}
