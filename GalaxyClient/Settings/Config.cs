using MelonLoader;
using System;
using System.IO;

namespace Galaxy.Settings
{
    internal class Config
    {
        public static bool ShouldFly = false;
        public static string GlowLocation = "";
        public static bool IsStaff = false;
        public static bool betaEnabled = false;
        public static string ExtraBeta = "0";
        public static string sendauth;
        public static bool hasAuth = false;
        public static string GlobalMessage = "";
        public static bool ServerNotify = false;
        protected internal static bool DUMPERFOUND = false;
    }

    [Serializable]

    internal class configa
    {
        public string QuestCrash { get; set; }
        public string PCCrash { get; set; }
        public bool ESP { get; set; }
        public string CurentWorld { get; set; }
        public bool Shouldrejoin { get; set; }
        public bool EnableKeybinds { get; set; }
        public string QuickAvi1 { get; set; }
        public string QuickAvi2 { get; set; }
        public string QuickAvi3 { get; set; }
        public string QuickAvi4 { get; set; }
        public string LoadMusic { get; set; }
        public bool ShouldPlayLoadMusic { get; set; }
        public bool AutoSkybox { get; set; }
    }

    internal class nconfig
    {
        public static void saveconfig(string path)
        {
            var sv = new configa()
            {
                QuestCrash = QuestCrash,
                PCCrash = PCCrash,
                ESP = ESP,
                CurentWorld = CurentWorld,
                Shouldrejoin = Shouldrejoin,
                EnableKeybinds = EnableKeybinds,
                QuickAvi1 = QuickAvi1,
                QuickAvi2 = QuickAvi2,
                QuickAvi3 = QuickAvi3,
                QuickAvi4 = QuickAvi4,
                LoadMusic = LoadMusic,
                ShouldPlayLoadMusic = ShouldPlayLoadMusic,
                AutoSkybox = AutoSkybox,
            };
            try
            { File.WriteAllText(path, $"{Newtonsoft.Json.JsonConvert.SerializeObject(sv)}"); }
            catch
            { API.LogHandler.Error("Failed to save config if you just started VRCHAT dont worry if not please alert Glow", "Config Saver"); }
        }


        public static void applyconfig(string path, configa sta)
        {
            QuestCrash = (string)sta.QuestCrash;
            PCCrash = (string)sta.PCCrash;
            ESP = (bool)sta.ESP;
            CurentWorld = (string)sta.CurentWorld;
            Shouldrejoin = (bool)sta.Shouldrejoin;
            EnableKeybinds = (bool)sta.EnableKeybinds;
            QuickAvi1 = (string)sta.QuickAvi1;
            QuickAvi2 = (string)sta.QuickAvi2;
            QuickAvi3 = (string)sta.QuickAvi3;
            QuickAvi4 = (string)sta.QuickAvi4;
            ShouldPlayLoadMusic = (bool)sta.ShouldPlayLoadMusic;
            LoadMusic = (string)sta.LoadMusic;
            AutoSkybox = (bool)sta.AutoSkybox;
            
            saveconfig(path);
        }

        public static string QuestCrash = "avtr_0c8a5fad-fab9-4940-8c50-dc638b52f41b";
        public static string PCCrash = "avtr_0c8a5fad-fab9-4940-8c50-dc638b52f41b";
        public static bool ESP = false;
        public static string CurentWorld = "";
        public static bool Shouldrejoin = false;
        public static bool EnableKeybinds = false;
        public static string QuickAvi1 = "";
        public static string QuickAvi2 = "";
        public static string QuickAvi3 = "";
        public static string QuickAvi4 = "";
        public static string LoadMusic = "https://api.galaxyvrc.xyz/Galaxy/assets/LoadingMusic.mp3";
        public static bool ShouldPlayLoadMusic = true;
        public static bool AutoSkybox = false;
    }

    internal class confirmauth
    {
        public string key { get; set; }
        public string Hwida { get; set; }
        public string code { get; set; }
        public string ExtraBeta { get; set; }
    }

    internal class sendsinglemsg
    {
        public string Custommsg { get; set; }
        public string code { get; set; }
    }

    internal class Logavi
    {
        public string AvatarName { get; set; }
        public string Author { get; set; }
        public string Authorid { get; set; }
        public string Avatarid { get; set; }
        public string Description { get; set; }
        public string Asseturl { get; set; }
        public string Image { get; set; }
        public string Platform { get; set; }
        public string Status { get; set; }
        public string code { get; set; }
    }
}

  

