using System;
using HarmonyLib;
using PlatformCustomizer.Configuration;

namespace PlatformCustomizer.HarmonyPatches
{
    [HarmonyPatch(typeof(ScoreMultiplierUIController), nameof(ScoreMultiplierUIController.HandleMultiplierDidChange))]
    static class DisableMultiplier
    {
        static bool Prefix()
        {
            bool set;
            if (PluginConfig.Instance.DisableMultiplier == true)
            {
                set = false;
            }
            else
            {
                set = true;
            }

            return set;
               
        }
    }
}
