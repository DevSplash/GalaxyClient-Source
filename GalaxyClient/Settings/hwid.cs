using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MelonLoader;
using Newtonsoft.Json;
using System.IO;
using System.Collections;
using UnityEngine;
using System.Diagnostics;

namespace Galaxy.settings
{
        internal class gethwid
        {
            public static void getinfo(ref string strings)
            {

                string name = "SOFTWARE\\Microsoft\\Cryptography";
                string name2 = "MachineGuid";
                using (RegistryKey registryKey = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64))
                {
                    using (RegistryKey registryKey2 = registryKey.OpenSubKey(name))
                    {
                        if (registryKey2 != null)
                        {
                            object value = registryKey2.GetValue(name2);
                            if (value != null)
                                strings = value.ToString();

                        }
                    }
                }
            }

            public static void sendc(string key)
            {


            File.WriteAllText($"{MelonUtils.GameDirectory}\\Galaxy\\Galaxy.key", key);
            getinfo(ref Settings.Config.sendauth);

            var abc = new Settings.confirmauth()
            {
                key = key,

                Hwida = Settings.Config.sendauth,

                code = "18",
            };

            string abcs = $"{JsonConvert.SerializeObject(abc)}";

            connect.sendmsg($"{abcs}");


                var ab = new Settings.confirmauth()
                {
                    key = File.ReadAllText($"{MelonUtils.GameDirectory}\\Galaxy\\Galaxy.key"),

                    Hwida = Settings.Config.sendauth,
                    
                    ExtraBeta = Settings.Config.ExtraBeta,

                    code = "14",
                };

                string abs = $"{JsonConvert.SerializeObject(ab)}";
                connect.sendmsg($"{abs}");

            }

        }


    }


