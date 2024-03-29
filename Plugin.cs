﻿using BepInEx;
using BepInEx.Logging;
using HarmonyLib;

namespace BetterControls
{
    public static class Globals
    {
        public const string PLUGIN_GUID = "muck.mrboxxy.bettercontrols";
        public const string PLUGIN_NAME = "BetterControls";
        public const string PLUGIN_VERSION = "1.1.1";
    }

    [BepInPlugin(Globals.PLUGIN_GUID, Globals.PLUGIN_NAME, Globals.PLUGIN_VERSION)]
    [BepInDependency("Terrain.MuckSettings")]
    public class Plugin : BaseUnityPlugin
    {
        public static ManualLogSource Log;

        public Harmony harmony;

        private void Awake()
        {
            // Plugin startup logic
            Log = base.Logger;

            harmony = new Harmony(Globals.PLUGIN_NAME);

            // this line is very important, anyone using this as an example shouldn't forget to copy-paste this as well!
            ControlsConfig.Config.SaveOnConfigSet = true;

            harmony.PatchAll(typeof(ControlsConfig));
            Log.LogInfo("Patched MuckSettings.Settings.Controls()");

            harmony.PatchAll(typeof(PingControllerPatch.PrefixesAndPostfixes));
            Log.LogInfo("Patched PingController.Update()");

            harmony.PatchAll(typeof(ChatBoxPatch.PrefixesAndPostfixes));
            Log.LogInfo("Patched ChatBox.UserInput()");

            harmony.PatchAll(typeof(LobbyVisualPatch.PrefixesAndPostfixes));
            Log.LogInfo("Patched LobbyVisual.Awake()");

            harmony.PatchAll(typeof(HotbarPatch.UpdateTranspiler));
            harmony.PatchAll(typeof(HotbarPatch.PrefixesAndPostfixes));
            Log.LogInfo("Patched Hotbar.Update()");

            harmony.PatchAll(typeof(InventoryCellPatch.PrefixesAndPostfixes));
            Log.LogInfo("Patched InventoryCell.OnPointerDown()");
            Log.LogInfo("Patched InventoryCell.ShiftClick()");

            harmony.PatchAll(typeof(PlayerInputPatch.MyInputTranspiler));
            harmony.PatchAll(typeof(PlayerInputPatch.PrefixesAndPostfixes));
            Log.LogInfo("Patched PlayerInput.MyInput()");

            harmony.PatchAll(typeof(BuildManagerPatch.PrefixesAndPostfixes));
            Log.LogInfo("Patched BuildManager.Awake()");
        }
    }
}
