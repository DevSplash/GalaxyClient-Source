using MelonLoader;
using System;
using System.Collections;
using System.IO;
using VRC.Core;

namespace Galaxy.API
{
    internal class CheckAuth
    {
        public static IEnumerator CheckAuthMeth()
        {
            while (APIUser.CurrentUser == null)
                yield return null;

            if (File.ReadAllText($"{MelonUtils.GameDirectory}\\Galaxy\\Galaxy.key") == string.Empty)
            {
                Console.WriteLine("↓ Enter your key ↓");
                var keymsg = Console.ReadLine();
                settings.gethwid.getinfo(ref Settings.Config.sendauth);
                settings.gethwid.sendc(keymsg.Trim());
            }
            else
            {
                settings.gethwid.getinfo(ref Settings.Config.sendauth);
                settings.gethwid.sendc(File.ReadAllText($"{MelonUtils.GameDirectory}\\Galaxy\\Galaxy.key"));
            }


        }
    }
}
