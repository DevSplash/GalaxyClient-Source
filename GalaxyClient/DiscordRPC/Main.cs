using Galaxy.API;
using System;

namespace Galaxy.Discord
{
    internal static class DiscordManager
    {
        internal static DiscordRpc.RichPresence presence;
        internal static DiscordRpc.EventHandlers eventHandlers;

        internal static void Init()
        {
            //Downloader();
            LogHandler.Log("Discord", "Starting RPC");
            RPCINIT();
        }



        internal static void RPCINIT()
        {
            eventHandlers = default(DiscordRpc.EventHandlers);
            eventHandlers.errorCallback = delegate (int code, string message) { };
            presence.state = $".gg/HyperV";

            presence.details = "all these stars and i still only want you";
            presence.largeImageKey = "https://api.galaxyvrc.xyz/Galaxy/DCRPC.jpg";
            presence.largeImageText = "By HyperV";
            presence.smallImageKey = "<3";
            presence.smallImageText = ".gg/HyperV";
            presence.partySize = 0;
            presence.partyMax = 0;
            presence.startTimestamp = (long)DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1)).TotalSeconds;
            presence.partyId = "";
            presence.spectateSecret = "IDK";
            try
            {
                DiscordRpc.Initialize("987909418366681118", ref eventHandlers, true, "");
                DiscordRpc.UpdatePresence(ref presence);

            }
            catch { }

        }


    }
}
