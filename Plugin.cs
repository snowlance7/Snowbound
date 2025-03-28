using BepInEx;
using BepInEx.Configuration;
using BepInEx.Logging;
using HarmonyLib;
using REPOLib.Objects.Sdk;
using System.Collections.Generic;
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
        public const string modVersion = "1.1.0";

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public static Plugin PluginInstance;
        public static ManualLogSource LoggerInstance;
        public static AssetBundle ModAssets;
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

        private readonly Harmony harmony = new Harmony(modGUID);

        public static ConfigEntry<bool> configEnableGlitchStatue;
        public static ConfigEntry<bool> configEnableDiceMimicPlush;
        public static ConfigEntry<bool> configEnableFuMolaniePlush;
        public static ConfigEntry<bool> configEnableSCP956;
        public static ConfigEntry<bool> configEnableNuke;
        public static ConfigEntry<bool> configEnableSCP999Plush;
        public static ConfigEntry<bool> configEnableSCP999Jar;
        public static ConfigEntry<bool> configEnableFunoPlush;

        public void Awake()
        {
            if (PluginInstance == null)
            {
                PluginInstance = this;
            }

            LoggerInstance = PluginInstance.Logger;

            harmony.PatchAll();

            configEnableGlitchStatue = Config.Bind("Valuables", "Enable Glitch Statue", true, "Enable or disable the Glitch Statue.");
            configEnableDiceMimicPlush = Config.Bind("Valuables", "Enable Dice Mimic Plush", true, "Enable or disable the Dice Mimic Plush.");
            configEnableFuMolaniePlush = Config.Bind("Valuables", "Enable Fu Molanie Plush", true, "Enable or disable the Fu Molanie Plush.");
            configEnableSCP956 = Config.Bind("Valuables", "Enable SCP-956", true, "Enable or disable SCP-956.");
            configEnableNuke = Config.Bind("Valuables", "Enable Nuke", true, "Enable or disable the Nuke.");
            configEnableSCP999Plush = Config.Bind("Valuables", "Enable SCP-999 Plush", true, "Enable or disable SCP-999 Plush.");
            configEnableSCP999Jar = Config.Bind("Items", "Enable SCP-999 Jar", true, "Enable or disable SCP-999 Jar.");
            configEnableFunoPlush = Config.Bind("Valuables", "Enable Funo Plush", true, "Enable or disable Funo Plush.");


            ModAssets = AssetBundle.LoadFromFile(Path.Combine(Path.GetDirectoryName(Info.Location), "snowbound_assets"));

            // Valuables Presets:
            // "Valuables - Generic"
            // "Valuables - Wizard"
            // "Valuables - Manor"
            // "Valuables - Arctic"

            List<string> genericList = new List<string>();
            genericList.Add("Valuables - Generic");

            RegisterValuable("Assets/ModAssets/Snowbound/GlitchStatue/GlitchStatue.prefab", genericList, configEnableGlitchStatue.Value);
            RegisterValuable("Assets/ModAssets/Snowbound/DiceMimicPlush/DiceMimic.prefab", genericList, configEnableDiceMimicPlush.Value);
            RegisterValuable("Assets/ModAssets/Snowbound/FuMolaniePlush/FuMolaniePlush.prefab", genericList, configEnableFuMolaniePlush.Value);
            RegisterValuable("Assets/ModAssets/Snowbound/SCP999Plush/SCP999Plush.prefab", genericList, configEnableSCP999Plush.Value);
            RegisterValuable("Assets/ModAssets/Snowbound/FunoPlush/FunoPlush.prefab", genericList, configEnableFunoPlush.Value);
            //RegisterItem("Assets/ModAssets/Snowbound/WIP/SCP999Jar/SCP999JarItem.asset", configEnableSCP999Jar.Value);

            RegisterValuable("Assets/ModAssets/Snowbound/SCP956/SCP956.prefab", genericList, configEnableSCP956.Value);
            RegisterValuable("Assets/ModAssets/Snowbound/Candy/CandyBlue.prefab", genericList, configEnableSCP956.Value);
            RegisterValuable("Assets/ModAssets/Snowbound/Candy/CandyGreen.prefab", genericList, configEnableSCP956.Value);
            RegisterValuable("Assets/ModAssets/Snowbound/Candy/CandyPink.prefab", genericList, configEnableSCP956.Value);
            RegisterValuable("Assets/ModAssets/Snowbound/Candy/CandyPurple.prefab", genericList, configEnableSCP956.Value);
            RegisterValuable("Assets/ModAssets/Snowbound/Candy/CandyRainbow.prefab", genericList, configEnableSCP956.Value);
            RegisterValuable("Assets/ModAssets/Snowbound/Candy/CandyRed.prefab", genericList, configEnableSCP956.Value);
            RegisterValuable("Assets/ModAssets/Snowbound/Candy/CandyYellow.prefab", genericList, configEnableSCP956.Value);

            List<string> nukeLevels = new List<string>();
            nukeLevels.Add("Valuables - Arctic");
            RegisterValuable("Assets/ModAssets/Snowbound/Nuke/Nuke.prefab", nukeLevels, configEnableNuke.Value);

            Logger.LogInfo($"{modGUID} v{modVersion} has loaded!");
        }

        public void RegisterValuable(string path, List<string> levelsList, bool enable = true)
        {
            if (!enable) { return; }
            GameObject ValuablePrefab = ModAssets.LoadAsset<GameObject>(path);
            REPOLib.Modules.Valuables.RegisterValuable(ValuablePrefab, levelsList);
        }

        public void RegisterItem(string path, bool enable = true)
        {
            if (!enable) { return; }
            ItemContent item = ModAssets.LoadAsset<ItemContent>(path);
            REPOLib.Modules.Items.RegisterItem(item.Prefab.item);
        }
    }
}