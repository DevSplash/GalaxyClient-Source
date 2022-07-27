using MelonLoader;
using System.IO;
using System.Net;

namespace Galaxy.API.Utils
{
    internal class Install
    {
        public static void InstallBC()
        {
            var wc = new WebClient();
            wc.Headers["User-Agent"] = "GalaxyKEKDLFILE";


            if (!Directory.Exists($"{MelonUtils.GameDirectory}\\Galaxy"))
            {
                Directory.CreateDirectory($"{MelonUtils.GameDirectory}\\Galaxy");
            }
            if (!File.Exists($"{MelonUtils.GameDirectory}\\Galaxy\\Galaxy.key"))
            {
                File.Create($"{MelonUtils.GameDirectory}\\Galaxy\\Galaxy.key");
                //Settings.nconfig.saveconfig($"{MelonUtils.GameDirectory}\\Galaxy\\Config\\GenConfig.json");
                LogHandler.Log("Config", "Created KeyFile", false);
            }
           

            if (!Directory.Exists($"{MelonUtils.GameDirectory}\\Galaxy\\Dependencies"))
            {
                Directory.CreateDirectory($"{MelonUtils.GameDirectory}\\Galaxy\\Dependencies");
            }

            if (!Directory.Exists($"{MelonUtils.GameDirectory}\\Galaxy\\Config"))
            {
                Directory.CreateDirectory($"{MelonUtils.GameDirectory}\\Galaxy\\Config");
            }

            if (!File.Exists($"{MelonUtils.GameDirectory}\\Galaxy\\Config\\GenConfig.json"))
            {
                File.Create($"{MelonUtils.GameDirectory}\\Galaxy\\Config\\GenConfig.json");
                //Settings.nconfig.saveconfig($"{MelonUtils.GameDirectory}\\Galaxy\\Config\\GenConfig.json");
                LogHandler.Log("Config", "Created Config", false);
            }
            else
            {
                Main.Load.LoadConfig();
                LogHandler.Log("Config", "Loading Config");
            }

            if (!File.Exists($"{MelonUtils.GameDirectory}\\Galaxy\\Dependencies\\discord-rpc.dll"))
            {
                wc.DownloadFile("https://api.galaxyvrc.xyz/Galaxy/Dependencies/discord-rpc.dll", $"{MelonUtils.GameDirectory}\\Galaxy\\Dependencies\\discord-rpc.dll");
                MelonLogger.Msg($"[\u001b[36;1mGalaxyClient\u001b[0m] [Downloader]: [Success] Downloaded DiscordRPC");
            }
            if (!File.Exists($"{MelonUtils.GameDirectory}\\Galaxy\\Dependencies\\clientassetbundle"))
            {
                wc.DownloadFile("https://api.galaxyvrc.xyz/Galaxy/Dependencies/clientassetbundle", $"{MelonUtils.GameDirectory}\\Galaxy\\Dependencies\\clientassetbundle");
                MelonLogger.Msg($"[\u001b[36;1mGalaxyClient\u001b[0m] [Downloader]: [Success] Downloaded ClientAssetBundle");
            }
            Settings.nconfig.saveconfig($"{MelonUtils.GameDirectory}\\Galaxy\\Config\\GenConfig.json");
        }

    }

}
