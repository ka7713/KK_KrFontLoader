using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using BepInEx;

namespace KK_KrFontLoader
{
    [BepInPlugin(IdentBepin, Name, Version)]
    [BepInDependency(Dependency_GUID_XUnity_AutoTranslator_Plugin)]
    [BepInProcess(ProcessName_Game)]
    [BepInProcess(ProcessName_GameSteam)]
    [BepInProcess(ProcessName_VR)]
    [BepInProcess(ProcessName_VRSteam)]
    [BepInProcess(ProcessName_Studio)]
    internal class Plugin : BaseUnityPlugin
    {
        const string IdentBepin = "goodcat.koikatu.kk_krfontloader";
        const string Name = "KK_KrFontLoader";
        const string Version = "1.2.0";
        const string Dependency_GUID_XUnity_AutoTranslator_Plugin = "gravydevsupreme.xunity.autotranslator";
        const string ProcessName_Game = "Koikatu";
        const string ProcessName_GameSteam = "Koikatsu Party";
        const string ProcessName_VR = "KoikatuVR";
        const string ProcessName_VRSteam = "Koikatsu Party VR";
        const string ProcessName_Studio = "CharaStudio";

        public const string Font_Path = "KK_KrFontLoader.Resources.kr_font.unity3d";
        public const string Font_Chat = "Chat_Font";
        public const string Font_TMP = "TMP_Font";

        static BepInEx.Logging.ManualLogSource baseLogger;

        internal void Main()
        {
            baseLogger = Logger;
            Hooks.InstallHooks();
        }

        public static void LogError(string format, params object[] args)
        {
            if (baseLogger is null)
                return;
            baseLogger.LogError(string.Format(format, args));
        }

        public static void LogMessage(string format, params object[] args)
        {
            if (baseLogger is null)
                return;
            baseLogger.LogMessage(string.Format(format, args));
        }
    }
}
