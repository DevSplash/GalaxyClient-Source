using Newtonsoft.Json;
using System;
using System.Timers;

namespace Galaxy.API
{
    internal class CheckServer
    {
        private static Timer CHECKSERVER;

        private static bool started = false;

        public static void SetTimer()
        {
            // Create a timer with a two second interval.
            CHECKSERVER = new System.Timers.Timer(15000);
            // Hook up the Elapsed event for the timer. 
            CHECKSERVER.Elapsed += IsUp;
            CHECKSERVER.AutoReset = true;
            CHECKSERVER.Enabled = true;

            if (started == false)
            { started = true;
                LogHandler.Log("Starter", $"Started Server Heartbeat", true);
            }
        }

        private static void IsUp(Object source, ElapsedEventArgs e)
        {
            AntiDump.AntiDump.ANTIDUMERMETH();
            var sendidtosv = new Settings.sendsinglemsg()
                {
                    Custommsg = "",

                    code = "20",
                };
                connect.sendmsg($"{JsonConvert.SerializeObject(sendidtosv)}");
            
        }
    }
}
