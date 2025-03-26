using BepInEx.Logging;
using HarmonyLib;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Rendering;
using static ChatManager;

namespace Snowbound
{
    [HarmonyPatch]
    public class PlayerHealthPatch
    {
        private static ManualLogSource logger = Plugin.LoggerInstance;

        /*[HarmonyPrefix]
        [HarmonyPatch(typeof(PlayerHealth), nameof(PlayerHealth.Hurt))]
        public static bool HurtPrefix()
        {
            if (RunManager.instance.levelCurrent == RunManager.instance.levelShop)
            {
                if (ChatManager.instance.betrayalActive) { return true; }
                return false;
            }

            return true;
        }*/
    }
}