using System;
using UnityEngine;
using HarmonyLib;
using PlatformCustomizer.Configuration;
using System.IO;
using System.Collections;

namespace PlatformCustomizer.HarmonyPatches
{
    [HarmonyPatch(typeof(ScoreMultiplierUIController), nameof(ScoreMultiplierUIController.HandleMultiplierDidChange))]
    static class DisableMultiplierAnim
    {
        static bool Prefix()
        {
            return false;
        }
    }
        
}
