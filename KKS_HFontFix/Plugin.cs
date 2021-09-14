using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using BepInEx;
using HarmonyLib;
using TMPro;

namespace KKS_HFontFix
{
    [BepInPlugin(IdentBepin, Name, Version)]
    [BepInDependency(Dependency_GUID_XUnity_AutoTranslator_Plugin)]
    internal class Plugin : BaseUnityPlugin
    {
        const string IdentBepin = "goodcat.koikatu_sunshine.KKS_HFontFix";
        const string Name = "KKS_HFontFix";
        const string Version = "1.0.0";
        const string Dependency_GUID_XUnity_AutoTranslator_Plugin = "gravydevsupreme.xunity.autotranslator";
        static BepInEx.Logging.ManualLogSource baseLogger;

        internal void Main()
        {
            baseLogger = Logger;

            try
            {
                Harmony.CreateAndPatchAll(typeof(Plugin));
            }
            catch (Exception e)
            {
                baseLogger.LogError($"ERROR WHILE INITIALIZING : {Environment.NewLine} {e}");
            }
        }

        static void FixFontSize(object graphic)
        {
			try
			{
                if (!(graphic is TextMeshProUGUI))
                    return;

                var tt = (TextMeshProUGUI)graphic;

                /*애무
                [Info: Console]--------------------
                [Info: Console] Scene: MinsyukuOutside
                [Info: Console] Root: Canvas
                [Info: Console]++++ ScrollMask
                [Info: Console]++++ MainManuNode(Clone)
                [Info: Console]++++ AibuCategory
                [Info: Console]++++ Viewport
                [Info: Console]++++ Aibu
                [Info: Console]++++ ActionSubMenu
                [Info: Console]++++ Canvas
                [Info: Console]--------------------

                손발
                [Info: Console] Scene: MinsyukuOutside
                [Info: Console] Root: Canvas
                [Info: Console]++++ ScrollMask
                [Info: Console]++++ MainManuNode(Clone)
                [Info: Console]++++ HandCategory
                [Info: Console]++++ Viewport
                [Info: Console]++++ Hand
                [Info: Console]++++ ActionSubMenu
                [Info: Console]++++ Canvas
                [Info: Console]--------------------

                입
                [Info: Console]--------------------
                [Info: Console] Scene: MinsyukuOutside
                [Info: Console] Root: Canvas
                [Info: Console]++++ ScrollMask
                [Info: Console]++++ MainManuNode(Clone)
                [Info: Console]++++ MouthCategory
                [Info: Console]++++ Viewport
                [Info: Console]++++ Mouth
                [Info: Console]++++ ActionSubMenu
                [Info: Console]++++ Canvas
                [Info: Console]--------------------

                가슴

                [Info: Console]--------------------
                [Info: Console] Scene: MinsyukuOutside
                [Info: Console] Root: Canvas
                [Info: Console]++++ ScrollMask
                [Info: Console]++++ MainManuNode(Clone)
                [Info: Console]++++ BreastCategory
                [Info: Console]++++ Viewport
                [Info: Console]++++ Breast
                [Info: Console]++++ ActionSubMenu
                [Info: Console]++++ Canvas
                [Info: Console]--------------------

                삽입
                [Info: Console]--------------------
                [Info: Console] Scene: MinsyukuOutside
                [Info: Console] Root: Canvas
                [Info: Console]++++ ScrollMask
                [Info: Console]++++ MainManuNode(Clone)
                [Info: Console]++++ SonyuCategory
                [Info: Console]++++ Viewport
                [Info: Console]++++ Sonyu
                [Info: Console]++++ ActionSubMenu
                [Info: Console]++++ Canvas
                [Info: Console]--------------------
                */

                var p1 = tt.transform.parent;
                var p2 = p1?.transform.parent;
                var p3 = p2?.transform.parent;
                var p4 = p3?.transform.parent;
                var p5 = p4?.transform.parent;

#if DEBUG
                Console.WriteLine($"{p1?.name} - {p2?.name} - {p3?.name} - {p4?.name} - {p5?.name}");
#endif
                if (p1?.name == "ScrollMask" && (
                    // 애무
                    ( /*&& p2 == "MainManuNode(Clone)" &&*/ p3?.name == "AibuCategory" /*&& p4 == "Viewport"*/ && p5?.name == "Aibu") ||
                    // 손발
                    ( /*&& p2 == "MainManuNode(Clone)" &&*/ p3?.name == "HandCategory" /*&& p4 == "Viewport"*/ && p5?.name == "Hand") ||
                    // 입
                    ( /*&& p2 == "MainManuNode(Clone)" &&*/ p3?.name == "MouthCategory" /*&& p4 == "Viewport"*/ && p5?.name == "Mouth") ||
                    // 가슴
                    ( /*&& p2 == "MainManuNode(Clone)" &&*/ p3?.name == "BreastCategory" /*&& p4 == "Viewport"*/ && p5?.name == "Breast") ||
                    // 삽입
                    ( /*&& p2 == "MainManuNode(Clone)" &&*/ p3?.name == "SonyuCategory" /*&& p4 == "Viewport"*/ && p5?.name == "Sonyu")
                    ))
                {
                    if (tt.fontSize != 16)
                    {
#if DEBUG
                        Console.WriteLine($"+++++ {tt.name} {p1?.name} - {p2?.name} - {p3?.name} - {p4?.name} - {p5?.name} {tt.text}");
#endif
                        tt.fontSize = 16;
                    }
                }
            }
			catch (Exception e)
			{
				baseLogger.LogError(e.ToString());
			}
		}

        [HarmonyPostfix, HarmonyPatch(typeof(TMPro.TextMeshProUGUI), "Awake")]
        private static void TMPro_TextMeshProUGUI___Awake(TMPro.TextMeshProUGUI __instance)
        {
            FixFontSize(__instance);
        }
    }
}
