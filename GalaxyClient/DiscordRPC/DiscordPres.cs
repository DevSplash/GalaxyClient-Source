using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Runtime.InteropServices;



namespace Galaxy.Main
{
    internal static class load
    {
        [DllImport("user32.dll", EntryPoint = "SetWindowText")]
        public static extern bool SetWindowText(System.IntPtr hwnd, System.String lpString);
        [DllImport("user32.dll", EntryPoint = "FindWindow")]
        public static extern System.IntPtr FindWindow(System.String className, System.String windowName);

        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hwnd, int message, int wParam, IntPtr lParam);

        [DllImport("kernel32.dll")]
        static extern IntPtr GetConsoleWindow();

        private static IntPtr window;

        // all the requirms 
        public static string largeImage = "https://api.galaxyvrc.xyz/Galaxy/DCRPC.jpg";
        public static string largeImageText = "By HyperV";
        // public static string smallimage = "";
        //  public static string smallImageText = "";

#if DEBUG
        public static string details = "Either Working on Galaxy or Crashing";
#else
        public static string details = "HOLD ON TO ME";
#endif


        public static string state = ".gg/HyperV";

        public static void PresenceUpdater()
        {


            Discord.DiscordManager.presence.state = state;
            DiscordRpc.UpdatePresence(ref Discord.DiscordManager.presence);

            Discord.DiscordManager.presence.largeImageKey = largeImage;
            DiscordRpc.UpdatePresence(ref Discord.DiscordManager.presence);

            Discord.DiscordManager.presence.largeImageText = largeImageText;
            DiscordRpc.UpdatePresence(ref Discord.DiscordManager.presence);

            // Discord.DiscordManager.presence.smallImageKey = smallimage;
            // DiscordRpc.UpdatePresence(ref Discord.DiscordManager.presence);

            //  Discord.DiscordManager.presence.smallImageText = smallImageText;
            //   DiscordRpc.UpdatePresence(ref Discord.DiscordManager.presence);



            Discord.DiscordManager.presence.details = details;
            DiscordRpc.UpdatePresence(ref Discord.DiscordManager.presence);

            Console.Title = $"Galaxy Client by HyperV";
            window = FindWindow(null, "VRChat");
            SetWindowText(window, "Galaxy Client By HyperV");
            Process[] processes = Process.GetProcessesByName("Discord");


            var bytess = new WebClient().DownloadData("http://api.galaxyvrc.xyz/favicon.ico");
            Stream stream = new MemoryStream(bytess);

            // SendMessage(window, WM_SETICON, ICON_BIG);

            foreach (Process p in processes)
            {
                IntPtr windowHandle = p.MainWindowHandle;
                var bytess2 = new WebClient().DownloadData("https://nocturnal-client.xyz/cl/Discord%202.ico");
                Stream stream2 = new MemoryStream(bytess2);
                //Icon icon2 = new Icon(stream2);
                // SendMessage(windowHandle, WM_SETICON, ICON_BIG, icon2.Handle);
            }



        }

        private const int WM_SETICON = 0x80;
        private const int ICON_SMALL = 0;
        private const int ICON_BIG = 1;

    }
}