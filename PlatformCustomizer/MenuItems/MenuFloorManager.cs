using System;
using System.Collections.Generic;
using PlatformCustomizer.Configuration;
using BeatSaberMarkupLanguage;
using Zenject;
using UnityEngine;
using Object = UnityEngine.Object;
using System.IO;
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
        private GameObject _menuPlatform;
        private readonly PlatformGrabber _platformGrabber;

        private Vector3 position;
        private Vector3 scale;

        public MenuFloorManager(PlatformGrabber platformGrabber)
        {
            _platformGrabber = platformGrabber;
        }
        
        public void Initialize()
        {
            //var loadedAssetBundle = AssetBundle.LoadFromMemory(Utilities.GetResource(Assembly.GetExecutingAssembly(), "PlatformCustomizer.Assets.menuplatform"));
            //_menuPlatform = loadedAssetBundle.LoadAllAssets<GameObject>();
            //loadedAssetBundle.Unload(false);

            if (_platformGrabber.completed)
            {
                if (config.EnableMenuPlatform == true)
                {
                    InstantiatePlatform();
                    return;
                }
                return;
            }
        }

        private void InstantiatePlatform()
        {


            _menuPlatform = new GameObject()
            {
                name = "MenuPlatform"
            };

            _menuPlatform = Object.Instantiate(PlatformGrabber.TemplatePlatform, new Vector3(0f, 0.1f, 0f), Quaternion.Euler(new Vector3(0f, 0f)), _menuPlatform.transform);
            _instantiatedPlatform = true;
        }
        

        public void Dispose()
        {
            //AssetBundle.UnloadAllAssetBundles(true);
            _platformGrabber.CompletedEvent -= InstantiatePlatform;
        }

    }
}
