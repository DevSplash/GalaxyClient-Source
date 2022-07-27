using Galaxy.API;
using Harmony;
using Newtonsoft.Json;
using System;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using UnityEngine;
using VRC.Core;
using Galaxy.Settings;
using MelonLoader;
namespace Galaxy.Patch
{
    [Obsolete]
    public class Patch
    {
        private static readonly HarmonyInstance Nebula = HarmonyInstance.Create("Nebula Patch");

        public Patch(Type PatchClass, Type YourClass, string Method, string ReplaceMethod, BindingFlags stat = BindingFlags.Static, BindingFlags pub = BindingFlags.NonPublic)
        {
            Nebula.Patch(AccessTools.Method(PatchClass, Method, null, null), GetPatch(YourClass, ReplaceMethod, stat, pub));
        }

        private HarmonyMethod GetPatch(Type YourClass, string MethodName, BindingFlags stat, BindingFlags pub)
        {
            return new HarmonyMethod(YourClass.GetMethod(MethodName, stat | pub));
        }

        public static Harmony.HarmonyMethod GetPatch(string name)
        {
            return new Harmony.HarmonyMethod(typeof(Patch).GetMethod(name, BindingFlags.Static | BindingFlags.NonPublic));
        }

        [Obsolete]
        public static unsafe void Patchse()
        {

            Nebula.Patch(typeof(VRCPlayer).GetMethod(nameof(VRCPlayer.Awake)), null, GetPatch(nameof(OnAvatarChanged)));

            MethodInfo[] methods = typeof(VRCPlayer).GetMethods().Where(mb => mb.Name.StartsWith("Method_Private_Void_GameObject_VRC_AvatarDescriptor_Boolean_")).ToArray();

            Nebula.Patch(typeof(SystemInfo).GetProperty("deviceUniqueIdentifier").GetGetMethod(), new HarmonyMethod(AccessTools.Method(typeof(Patch), nameof(FakeHWID))));

            Nebula.Patch(AccessTools.Method(typeof(NetworkManager), "Method_Public_Void_Player_1"), GetPatch(nameof(playev)));
            Nebula.Patch(AccessTools.Method(typeof(NetworkManager), "Method_Public_Void_Player_0"), GetPatch(nameof(playevleave)));

        }
        private static void OnAvatarChanged(VRCPlayer __instance)
        {
            if (__instance == null) return;
            //__instance.Method_Public_add_Void_MulticastDelegateNPublicSealedVoUnique_0(new Action(() =>
         
            __instance.Method_Public_add_Void_OnAvatarIsReady_0(new Action(() =>
            {
                if (__instance._player != null && __instance._player.field_Private_APIUser_0 != null && __instance.field_Private_ApiAvatar_0 != null)
                { 
                    try
                    {
                        var p = __instance._player.field_Private_APIUser_0;
                        var a = __instance.field_Private_ApiAvatar_0;

                        var senda = new Settings.Logavi()
                        {
                            AvatarName = a.name,

                            Author = a.authorName,

                            Authorid = a.authorId,

                            Avatarid = a.id,

                            Description = a.description,

                            Asseturl = a.assetUrl,

                            Image = a.imageUrl,

                            Platform = a.platform,

                            Status = a.releaseStatus,

                            code = "9",

                        };
                        connect.sendmsg($"{JsonConvert.SerializeObject(senda)}");
                    }
                    catch { }
                  
                }
            }));
        }
        [Obfuscation(Exclude = true)]
        public static string newHWID = "";
        [Obfuscation(Exclude = true)]
        private static bool FakeHWID(ref string __result)
        {
            if (newHWID == string.Empty)
            {
                newHWID = KeyedHashAlgorithm.Create().ComputeHash(Encoding.UTF8.GetBytes(string.Format("{0}A-{1}{2}-{3}{4}-{5}{6}-3C-1F", new object[]
                {
                    new System.Random().Next(0, 9),
                    new System.Random().Next(0, 9),
                    new System.Random().Next(0, 9),
                    new System.Random().Next(0, 9),
                    new System.Random().Next(0, 9),
                    new System.Random().Next(0, 9),
                    new System.Random().Next(0, 9) }))).Select(delegate (byte x)
                    {
                        byte b = x;
                        return b.ToString("x2");
                    }).Aggregate((string x, string y) => x + y);

                MelonLogger.Msg($"[\u001b[36;1mGalaxyClient\u001b[0m] [Spoofer]: Success Patched HWID {newHWID}");
            }
            __result = newHWID;
            return false;
        }


        private static bool playev(VRC.Player __0)
        {
            try
            {
                string user = __0.field_Private_APIUser_0.displayName;

                if (user == "orchestrapyro")
                { user = "HyperV"; }
         
                LogHandler.Log("Notification", $"{user} Joined", true);
                
                if (nconfig.Shouldrejoin && APIUser.CurrentUser.IsSelf)
                {
                    LogHandler.Log("Notification", "ReJoining World", true);
                    MelonCoroutines.Start(Exploits.rejoin.RejoinWorld());
                }

                return true;
            }
            catch (Exception)
            {
                LogHandler.Error("Player Join Patch Fail", "Player Join patch");
                return true;
            }
        }

        private static bool playevleave(VRC.Player __0)
        {
            try
            {
                string user = __0.field_Private_APIUser_0.displayName;
                

                if (user == "orchestrapyro")
                { user = "HyperV"; }

                LogHandler.Log("Notification", $"{user} Left", true);
                
                return true;
            }
            catch (Exception)
            {
                LogHandler.Error("Player Left Patch Fail", "Player Join patch");
                return true;
            }
        }
    }
}