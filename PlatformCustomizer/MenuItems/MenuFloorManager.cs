using System;
using PlatformCustomizer.Configuration;
using BeatSaberMarkupLanguage;
using Zenject;
using UnityEngine;
using Object = UnityEngine.Object;
using System.Collections;
using PlatformCustomizer.Miscellaneous;

namespace PlatformCustomizer.MenuItems
{  
    internal class MenuFloorManager : IInitializable, IDisposable
    {
        PluginConfig config = PluginConfig.Instance;
        public Vector3 scaleChange;
        public Vector3 fgChange;
        public Vector3 footScale;

        private bool _instantiatedPlatform;
        public GameObject _menuPlatform;
        public GameObject _platform;
        private PlatformGrabber _platformGrabber;

        private Vector3 position;
        private Vector3 scale;

        public MenuFloorManager(PlatformGrabber platformGrabber)
        {
            _platformGrabber = platformGrabber;
            
        }

        public void Initialize()
        {
            if (_platformGrabber.completed)
            {
                InstantiatePlatform();
                Plugin.Log.Info("AHIFUIH");
                return;
            }
            

            _platformGrabber.CompletedEvent += InstantiatePlatform;

           
        }


        private void InstantiatePlatform()
        {
            _platformGrabber.CompletedEvent -= InstantiatePlatform;
            Plugin.Log.Critical("Instantiating Platform");

            _menuPlatform = new GameObject
            {
                name = "MenuPlatform"
            };
            
            _platform = Object.Instantiate(PlatformGrabber.TemplatePlatform, new Vector3(0f, 0.01f, 0f), Quaternion.Euler(new Vector3(0f, 0f)), _menuPlatform.transform);

            var menuPlatform = GameObject.Find("MenuPlatform");
            if (config.EnableMenuPlatform == true)
            {
                menuPlatform.SetActive(true);
            }
            else
            {
                menuPlatform.SetActive(false);
            }

            _instantiatedPlatform = true;
        }
        

        public void Dispose()
        {
            //AssetBundle.UnloadAllAssetBundles(true);
            _platformGrabber.CompletedEvent -= InstantiatePlatform;
        }

    }
}

//var loadedAssetBundle = AssetBundle.LoadFromMemory(Utilities.GetResource(Assembly.GetExecutingAssembly(), "PlatformCustomizer.Assets.menuplatform"));
//_menuPlatform = loadedAssetBundle.LoadAllAssets<GameObject>();
//loadedAssetBundle.Unload(false);
