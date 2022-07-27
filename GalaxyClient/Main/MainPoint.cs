using Galaxy.API;
using Galaxy.Settings;
using MelonLoader;
using System;
using System.IO;
using System.Reflection;
using System.Threading;
using UnityEngine;


namespace Galaxy.Main
{
    internal class Load
    {
        [Obfuscation(Exclude = true, ApplyToMembers = true, StripAfterObfuscation = true)]
        private static Thread tr = new Thread(connect.Runsocket);
        [Obsolete]
        public static void OnStar()
        {
            if (Environment.CommandLine.Contains("--BETAMODE"))
            {
                MelonLogger.Warning($"[\u001b[36;1mGalaxyLoader\u001b[0m] [BETA]: BETA MODE ENABLED");
                Config.ExtraBeta = "1"; 
            }

            MelonCoroutines.Start(HudNotify.StartHudNotify());
            LogoShower.DisplayLogo();
            API.Utils.Install.InstallBC();
            Discord.DiscordManager.Init();
            MelonCoroutines.Start(Buttons.Buttonlayout.WaitForSM());
            MelonCoroutines.Start(CheckAuth.CheckAuthMeth());
            tr.Start();
            Patch.Patch.Patchse();
        }

        internal protected static void NONOMETHOD()
        {
            if (Input.GetKeyDown(KeyCode.F1) & nconfig.EnableKeybinds)
            { Exploits.QuickChange.QuickChangeAvi(); }
            if (Input.GetKeyDown(KeyCode.F2) & nconfig.EnableKeybinds)
            { Exploits.QuickChange.QuickChangeAvi2(); }
            if (Input.GetKeyDown(KeyCode.F3) & nconfig.EnableKeybinds)
            { Exploits.QuickChange.QuickChangeAvi3(); }
            if (Input.GetKeyDown(KeyCode.F4) & nconfig.EnableKeybinds)
            { Exploits.QuickChange.QuickChangeAvi4(); }

            if (Config.ServerNotify == true)
            { HudNotify.Msg("GlobalMessage", 4f); HudNotify.Msg(Config.GlobalMessage, 4f); Config.ServerNotify = false; }
            Exploits.Fly.FlyB();

            if (Config.DUMPERFOUND == true)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Found Dumper Alerting HyperV");
                Console.Beep();
            }

        }
        public static void OVERSLEEP()
        {
            try
            {
                MelonLogger.Msg($"[\u001b[36;1mGalaxyClient\u001b[0m] [Starter]: On Late Start Was Called Loading Now");
                nconfig.saveconfig($"{MelonUtils.GameDirectory}\\Galaxy\\Config\\GenConfig.json");   
                if (nconfig.ShouldPlayLoadMusic == true)
                { MelonCoroutines.Start(styles.LoadMods.Starter()); }
            }
            catch (Exception ex)
            { MelonLogger.Msg(ex); }
        }

        public static void Quitter()
        { nconfig.saveconfig($"{MelonUtils.GameDirectory}\\Galaxy\\Config\\GenConfig.json"); }

        public static void LoadConfig()
        {
            try
            {
                var mainl = Newtonsoft.Json.JsonConvert.DeserializeObject<configa>(File.ReadAllText($"{MelonUtils.GameDirectory}\\Galaxy\\Config\\GenConfig.json"));
                nconfig.applyconfig($"{MelonUtils.GameDirectory}\\Galaxy\\Config\\GenConfig.json", mainl);
            }
            catch
            { nconfig.saveconfig($"{MelonUtils.GameDirectory}\\Galaxy\\Config\\GenConfig.json"); LogHandler.Log("ABD ", "Saved Config"); }

        }
    }
}
