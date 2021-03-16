using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.IO;

using UnityEngine;
using HarmonyLib;

namespace KK_KrFontLoader
{
    internal class Hooks
	{
		public static void InstallHooks()
		{
			try
			{
                var harmony = Harmony.CreateAndPatchAll(typeof(Hooks));
            }
			catch (Exception e)
			{
				Plugin.LogError($"ERROR WHILE INITIALIZING : {Environment.NewLine} {e}");
			}
		}

        [HarmonyPostfix, HarmonyPatch(typeof(TMPro.TextMeshProUGUI), "Awake")]
        private static void TMPro_TextMeshProUGUI___Awake(TMPro.TextMeshProUGUI __instance)
        {
            ChangeFontTMP.SetFont(__instance);
        }

        [HarmonyPostfix, HarmonyPatch(typeof(TMPro.TextMeshPro), "Awake")]
        private static void TMPro_TextMeshPro__Awake(TMPro.TextMeshPro __instance)
        {
            ChangeFontTMP.SetFont(__instance);
        }

        [HarmonyPostfix, HarmonyPatch(typeof(UnityEngine.UI.Text), "text", MethodType.Setter)]
        private static void UnityEngine_UI_Text__text(UnityEngine.UI.Text __instance)
        {
            ChangeFontUGUI.SetFont(__instance);
        }
    }
}
