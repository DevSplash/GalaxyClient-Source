using Galaxy.API;
using System;
using System.Diagnostics;

namespace Galaxy.Buttons
{
    internal class ButInfo
    {
        public static void Info(QMTabMenu tabMenu)
        {
            var Info = new QMNestedButton(tabMenu, 2, 3, "Galaxy Info", "GalaxyInfo", "Galaxy Client");

            var Discord = new QMSingleButton(tabMenu, 1, 0, "Join The Discord", delegate
             { Process.Start("https://galaxyvrc.xyz/discord"); }, "Join The Discord");

            var Munch = new QMSingleButton(Info, 2, 0, "Munchen Client", delegate
            { Process.Start("https://shintostudios.net/"); }, "Go Get The client that Inspired Me");

            var Serenity = new QMSingleButton(Info, 3, 0, "Bots", delegate
            { Process.Start("https://discord.gg/vrcbots"); }, "SERENITY");
            
            // This Starts The supporter menu leave at bottom dont touch
            Supporters.Support(Info);
        }



    }

}

