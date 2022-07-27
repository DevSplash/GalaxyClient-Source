using System;
using System.Diagnostics;

namespace Galaxy.AntiDump
{
    internal class AntiDump
    {
        internal protected static void ANTIDUMERMETH()
        {
            Process[] processCollection = Process.GetProcesses();
            foreach (Process foo in processCollection)
            {
                try
                {
                    string processlower = foo.ProcessName.ToLower();

                    if (processlower == "exetremedumper")
                    {
                        Console.WriteLine("Found Possible Dumper");
                        foo.Kill();
                        Settings.Config.DUMPERFOUND = true;
                    }
                }
                catch
                { }
            }
        }

        protected static void DoPrintAntis()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Found Dumper Alerting HyperV");
            Console.Beep();
            Console.WriteLine("Found Dumper Alerting HyperV");
            Console.Beep();
            Console.WriteLine("Found Dumper Alerting HyperV");
            Console.Beep();
            Console.WriteLine("Found Dumper Alerting HyperV");
            Console.Beep();
            Console.WriteLine("Found Dumper Alerting HyperV");
            Console.Beep();
            Console.WriteLine("Found Dumper Alerting HyperV");
            Console.Beep();
            Console.WriteLine("Found Dumper Alerting HyperV");
            Console.Beep();
            Console.WriteLine("Found Dumper Alerting HyperV");
            Console.Beep();
            Console.WriteLine("Found Dumper Alerting HyperV");
            Console.Beep();
            Console.WriteLine("Found Dumper Alerting HyperV");
            Console.Beep();
            Console.WriteLine("Found Dumper Alerting HyperV");
            Console.Beep();
            Console.WriteLine("Found Dumper Alerting HyperV");
            Console.Beep();
            Console.WriteLine("Found Dumper Alerting HyperV");
            Console.Beep();
            Console.WriteLine("Found Dumper Alerting HyperV");
            Console.Beep();
            Console.WriteLine("Found Dumper Alerting HyperV");
            Console.Beep();
            Console.WriteLine("Found Dumper Alerting HyperV");
            Console.Beep();
            Console.WriteLine("Found Dumper Alerting HyperV");
            Console.Beep();
            Console.WriteLine("Found Dumper Alerting HyperV");
            Console.Beep();
            Console.WriteLine("Found Dumper Alerting HyperV");
            Console.Beep();
            Process.GetCurrentProcess().Kill();

        }

    }
}
