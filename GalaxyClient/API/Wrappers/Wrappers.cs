using Galaxy.API;
using UnityEngine;
using VRC;
using VRC.Core;
using VRC.UI;


namespace Galaxy.Wrappers
{
    internal class playerW
    {
        public static Player LocalPlayer
        {
            get
            {
                return Player.prop_Player_0;
            }
        }
    }
    internal class WorldW
    {
        public static bool IsInWorld()
        {
            return RoomManager.field_Internal_Static_ApiWorld_0 != null;
        }
    }

    internal class PlayerWrapper
    {
        internal static void ChangePlayerAvatar(string avatarId)
        {
            new ApiAvatar() { id = avatarId }.Get(new System.Action<ApiContainer>(x =>
            {
                GameObject.Find("UserInterface/MenuContent/Screens/Avatar").GetComponent<PageAvatar>().field_Public_SimpleAvatarPedestal_0.field_Internal_ApiAvatar_0 = x.Model.Cast<ApiAvatar>();
                GameObject.Find("UserInterface/MenuContent/Screens/Avatar").GetComponent<PageAvatar>().ChangeToSelectedAvatar();
            }),
            new System.Action<ApiContainer>(x =>
            {
                LogHandler.Log("Player", $"Failed to switch to avatar: {avatarId} ({x.Error})");
            }), null, false);
        }

        public static VRC.Player GetLocalPlayer()
        {
            return VRC.Player.prop_Player_0;
        }
    }
}


