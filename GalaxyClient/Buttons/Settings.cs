using Galaxy.API;
using Galaxy.Settings;
using MelonLoader;
using System;
using System.Diagnostics;
using VRC.Core;

namespace Galaxy.Buttons
{
    internal class ButtSettings
    {
        public static void SettingsMenu(QMTabMenu tabMenu)
        {
            var settingsmenu = new QMNestedButton(tabMenu, 1, 3, "Galaxy Settings", "GalaxySettings", "Galaxy Client");

            var RestartGame = new QMSingleButton(settingsmenu, 1, 3, "Restart Game", delegate
            {
                nconfig.saveconfig($"{MelonUtils.GameDirectory}\\Galaxy\\Config\\GenConfig.json");
                Exploits.rejoin.Restart();
            }, "Restart Game");

            var CloseGame = new QMSingleButton(settingsmenu, 2, 3, "Close Game", delegate
            {
                nconfig.saveconfig($"{MelonUtils.GameDirectory}\\Galaxy\\Config\\GenConfig.json");
                Process.GetCurrentProcess().Kill();
            }, "Close Game");

            // quick avis
            var SetCustomAvi1 = new QMSingleButton(settingsmenu, 1, 0, "Set Quick Avi 1", delegate
            {
                nconfig.QuickAvi1 = APIUser.CurrentUser.avatarId;
                nconfig.saveconfig($"{MelonUtils.GameDirectory}\\Galaxy\\Config\\GenConfig.json");
            }, "click to set avi 1");

            var SetCustomAvi2 = new QMSingleButton(settingsmenu, 2, 0, "Set Quick Avi 2", delegate
            {   nconfig.QuickAvi2 = APIUser.CurrentUser.avatarId;
                nconfig.saveconfig($"{MelonUtils.GameDirectory}\\Galaxy\\Config\\GenConfig.json");
            }, "click to set avi 2");

            var SetCustomAvi3 = new QMSingleButton(settingsmenu, 3, 0, "Set Quick Avi 3", delegate
            {
                nconfig.QuickAvi3 = APIUser.CurrentUser.avatarId;
                nconfig.saveconfig($"{MelonUtils.GameDirectory}\\Galaxy\\Config\\GenConfig.json");
            }, "click to set avi 3");

            var SetCustomAvi4 = new QMSingleButton(settingsmenu, 4, 0, "Set Quick Avi 4", delegate
            {
                nconfig.QuickAvi4 = APIUser.CurrentUser.avatarId;
                nconfig.saveconfig($"{MelonUtils.GameDirectory}\\Galaxy\\Config\\GenConfig.json");
            }, "click to set avi 4");

            var SetCustomQuest = new QMSingleButton(settingsmenu, 2, 1, "Set Quest Crasher", delegate
            { try { string AvatarID = "AVATAR ID"; API.inputpopout.run(" Avatar", value => AvatarID = value, () => { nconfig.QuestCrash = AvatarID; nconfig.saveconfig($"{MelonUtils.GameDirectory}\\Galaxy\\Config\\GenConfig.json"); }); } catch (Exception e) { Console.WriteLine(e); } }, "Change Avatar By ID");

            var SetCustomPC = new QMSingleButton(settingsmenu, 3, 1, "Set PC Crasher", delegate
            { try { string AvatarID = "AVATAR ID"; API.inputpopout.run(" Avatar", value => AvatarID = value, () => { nconfig.PCCrash = AvatarID; nconfig.saveconfig($"{MelonUtils.GameDirectory}\\Galaxy\\Config\\GenConfig.json"); }); } catch (Exception e) { Console.WriteLine(e); } }, "Set Pc Crasher");



            var TogglQuickKybinds = new QMToggleButton(settingsmenu, 4, 1, "KeyBinds", delegate
            {
                nconfig.EnableKeybinds = true;
                nconfig.saveconfig($"{MelonUtils.GameDirectory}\\Galaxy\\Config\\GenConfig.json");
            }, delegate
            {
                nconfig.EnableKeybinds = false;
                nconfig.saveconfig($"{MelonUtils.GameDirectory}\\Galaxy\\Config\\GenConfig.json");
            }, "Toggle Keybinds");


            var LoadMusicToggle = new QMToggleButton(settingsmenu, 1, 1, "LoadMusic", delegate
            {
                nconfig.ShouldPlayLoadMusic = true;
                MelonCoroutines.Start(styles.LoadMods.Starter());
                nconfig.saveconfig($"{MelonUtils.GameDirectory}\\Galaxy\\Config\\GenConfig.json");
            }, delegate
            {
                nconfig.ShouldPlayLoadMusic = false;
                nconfig.saveconfig($"{MelonUtils.GameDirectory}\\Galaxy\\Config\\GenConfig.json"); }, "Toggle Load Music");

            var AutoStarSky = new QMToggleButton(settingsmenu, 1, 2, "Star Sky", delegate
            {
                nconfig.AutoSkybox = true;
                nconfig.saveconfig($"{MelonUtils.GameDirectory}\\Galaxy\\Config\\GenConfig.json");
             
            }, delegate
            {
                nconfig.AutoSkybox = false;
                nconfig.saveconfig($"{MelonUtils.GameDirectory}\\Galaxy\\Config\\GenConfig.json");
            }, "Toggle AutoSkybox");

            if (nconfig.ShouldPlayLoadMusic == true)
            { LoadMusicToggle.ClickMe(); }

            if (nconfig.EnableKeybinds == true)
            { TogglQuickKybinds.ClickMe(); }

        }
    }
}
