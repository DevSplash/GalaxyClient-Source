using MelonLoader;

namespace Galaxy.API
{
    internal class LogHandler
    {
        internal static void Log(string Identify, string message, bool ShouldDisplay = false)
        {
            if (Settings.Config.hasAuth == true)
            {
                MelonLogger.Msg($"[\u001b[36;1mGalaxyClient\u001b[0m] [{Identify}]: {message}");

                if (ShouldDisplay == true)
                { HudNotify.Msg(message, 4f);}
            }
        }

        internal static void Error(string message, string Identify)
        {
            MelonLogger.Error($"[\u001b[36mGalaxyClient\u001b[31m] [{Identify}]: Send a screen shot of below Error");
            MelonLogger.Error($"[GalaxyClient] [{Identify}]: {message}");
        }

        internal static void Loader(string Identify, string message)
        {
            MelonLogger.Msg($"[\u001b[36;1mGalaxyLoader\u001b[0m] [{Identify}]: {message}");
        }
    }
}
