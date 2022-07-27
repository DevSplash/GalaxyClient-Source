using MelonLoader;
using System.Collections;
using UnhollowerRuntimeLib;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

namespace Galaxy.styles
{
    internal class LoadMods
    {
        public static IEnumerator Starter()
        {
            if (Settings.nconfig.ShouldPlayLoadMusic == true)
            {
                var clip = UnityWebRequest.Get(Settings.nconfig.LoadMusic);

                clip.SendWebRequest();
                while (!clip.isDone) yield return null;
                if (clip.isHttpError) yield break;

                var audioclip = WebRequestWWW.InternalCreateAudioClipUsingDH(clip.downloadHandler, clip.url, false, false, AudioType.UNKNOWN);

                audioclip.hideFlags = HideFlags.DontUnloadUnusedAsset;

                //load screen when the game first starts

                while (GameObject.Find("UserInterface/LoadingBackground_TealGradient_Music") == null) yield return null;

                var source1 = GameObject.Find("UserInterface/LoadingBackground_TealGradient_Music").transform.Find("LoadingSound").GetComponent<AudioSource>();
                source1.clip = audioclip;
                source1.Play();
              
                
    
                //every load screen after
                while (GameObject.Find("UserInterface/MenuContent/Popups/LoadingPopup") == null) yield return null;
                

                   var source2 = GameObject.Find("UserInterface/MenuContent/Popups/LoadingPopup").transform.Find("LoadingSound").GetComponent<AudioSource>();
                source2.clip = audioclip;
                source2.Play();
                GameObject.Find("UserInterface/MenuContent/Popups/LoadingPopup/3DElements/LoadingBackground_TealGradient").SetActive(false);
                yield return new WaitForSeconds(0.5f);
                

            }
        }

        public static IEnumerator LoadSkyBoxBundl2e()
        {var Color = new Color(0f, 0f, 0f);

            if (firstload == true)
            { yield return null; }
            while (GameObject.Find("UserInterface/MenuContent/Popups/LoadingPopup") == null) yield return null;
            //UI recolor and Make it look nice for loading
                            GameObject.Find("UserInterface/MenuContent/Popups/LoadingPopup/3DElements/LoadingInfoPanel").SetActive(false);
                GameObject.Find("UserInterface/MenuContent/Popups/LoadingPopup/ProgressPanel/Parent_Loading_Progress/Decoration_Right").SetActive(false);
                GameObject.Find("UserInterface/MenuContent/Popups/LoadingPopup/ProgressPanel/Parent_Loading_Progress/Decoration_Left").SetActive(false);
                GameObject.Find("UserInterface/MenuContent/Popups/LoadingPopup/ProgressPanel/Parent_Loading_Progress/Panel_Backdrop").SetActive(false);
                GameObject.Find("UserInterface/MenuContent/Popups/LoadingPopup/ProgressPanel/Parent_Loading_Progress/GoButton").GetComponent<Button>().image.color = Color;
                GameObject.Find("UserInterface/MenuContent/Popups/LoadingPopup/3DElements/LoadingBackground_TealGradient").SetActive(false);
            // var Color = new Color(0, 0.438850343f, 0.712937f);
           

            yield return new WaitForSeconds(.9f);
            
          
        }

        public static void LoadSkyWhenever2()
        {
            
            SkyBoxAssetBundle = AssetBundle.LoadFromFile($"{MelonUtils.GameDirectory}\\Galaxy\\Dependencies\\clientassetbundle");
            skyBoxMaterial = SkyBoxAssetBundle.LoadAsset_Internal("Load.mat", Il2CppType.Of<Material>()).Cast<Material>();
            Object.Instantiate<Material>(skyBoxMaterial);
            bool flag = skyBoxMaterial == null;
            if (flag)
            {
                API.LogHandler.Error("SkyBox Mat was null ping Hyper", "Skyboxes");
            }
            RenderSettings.skybox = skyBoxMaterial;
            SkyBoxAssetBundle.Unload(false);
            firstload = false;
        }

        private static AssetBundle SkyBoxAssetBundle { get; set; }
        private static Material skyBoxMaterial;
        public static bool firstload = true;
    }
}
