using System;
using System.Collections;
using System.Text;
using UnityEngine;
using VRC.Core;


namespace Galaxy
{
    internal class LogoShower
    {
        public static void DisplayLogo()
        {

            string fileVersion = "4";
            Console.Title = $"Galaxy || v{fileVersion}";
            Galaxy.API.LogHandler.Loader("Success", "Starting Galaxy Client Now");
#if DEBUG
            /*
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("========================================================================================================================");
            Console.WriteLine("                                                                                                                        ");
            Console.WriteLine("                                                                                                                        ");
            Console.WriteLine("              ░█████╗░██████╗░░█████╗░████████╗██╗░█████╗░  ░█████╗░██╗░░░░░██╗███████╗███╗░░██╗████████╗              ");
            Console.WriteLine("              ██╔══██╗██╔══██╗██╔══██╗╚══██╔══╝██║██╔══██╗  ██╔══██╗██║░░░░░██║██╔════╝████╗░██║╚══██╔══╝              ");
            Console.WriteLine("              ███████║██████╔╝██║░░╚═╝░░░██║░░░██║██║░░╚═╝  ██║░░╚═╝██║░░░░░██║█████╗░░██╔██╗██║░░░██║░░░             ");
            Console.WriteLine("              ██╔══██║██╔══██╗██║░░██╗░░░██║░░░██║██║░░██╗  ██║░░██╗██║░░░░░██║██╔══╝░░██║╚████║░░░██║░░░             ");
            Console.WriteLine("              ██║░░██║██║░░██║╚█████╔╝░░░██║░░░██║╚█████╔╝  ╚█████╔╝███████╗██║███████╗██║░╚███║░░░██║░░░             ");
            Console.WriteLine("              ╚═╝░ ╚═╝╚═╝░░╚═╝░╚════╝░░░░╚═╝░░░╚═╝░╚════╝░  ░╚════╝░╚══════╝╚═╝╚══════╝╚═╝░░╚══╝░░░╚═╝░░░             ");
            Console.WriteLine("                                                                                                                       ");
            Console.WriteLine("                                                                                                                       ");                                
            Console.WriteLine("========================================================================================================================\n");
            Console.ForegroundColor = ConsoleColor.White;
            */
#endif

        }
    }
}
