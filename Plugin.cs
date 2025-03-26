using BepInEx;
using BepInEx.Logging;
using HarmonyLib;
using REPOLib.Objects.Sdk;
using System.IO;
using UnityEngine;

namespace Snowbound
{
    [BepInPlugin(modGUID, modName, modVersion)]
    [BepInDependency(REPOLib.MyPluginInfo.PLUGIN_GUID, BepInDependency.DependencyFlags.HardDependency)]
    public class Plugin : BaseUnityPlugin
    {
        public const string modGUID = "Snowlance.Snowbound";
        public const string modName = "Snowbound";
        public const string modVersion = "1.0.0";

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public static Plugin PluginInstance;
        public static ManualLogSource LoggerInstance;
        public static AssetBundle ModAssets;
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

        private readonly Harmony harmony = new Harmony(modGUID);

        public void Awake()
        {
            if (PluginInstance == null)
            {
                PluginInstance = this;
            }

            LoggerInstance = PluginInstance.Logger;

            harmony.PatchAll();

            ModAssets = AssetBundle.LoadFromFile(Path.Combine(Path.GetDirectoryName(Info.Location), "snowbound_assets"));

            RegisterValuable("Assets/ModAssets/Snowbound/GlitchStatue/GlitchStatueValuable.asset");
            RegisterValuable("Assets/ModAssets/Snowbound/DiceMimicPlush/DiceMimicValuable.asset");
            RegisterValuable("Assets/ModAssets/Snowbound/FuMolaniePlush/FuMolaniePlushValuable.asset");

            Logger.LogInfo($"{modGUID} v{modVersion} has loaded!");
        }

        public void RegisterValuable(string path)
        {
            ValuableContent ValuablePrefab = ModAssets.LoadAsset<ValuableContent>(path);
            REPOLib.Modules.Valuables.RegisterValuable(ValuablePrefab.Prefab);
        }
    }
}