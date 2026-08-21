using System.Collections;
using IPA;
using IPA.Config.Stores;
using IPALogger = IPA.Logging.Logger;
using SiraUtil.Zenject;
using PlatformCustomizer.Configuration;
using PlatformCustomizer.UI;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Reflection;
using BeatSaberMarkupLanguage;

namespace PlatformCustomizer
{
    [Plugin(RuntimeOptions.SingleStartInit)]
    public class Plugin
    {
        internal static Plugin Instance { get; private set; }
        internal static IPALogger Log { get; private set; }
        public GameObject feet = GameObject.Find("Feet");
        public GameObject _gameObject;
        public GameObject MenuPlat;
        readonly PluginConfig config = PluginConfig.Instance;
        public GameObject menuPlatParent;

        [Init]
        public void Init(Zenjector zenject, IPALogger logger, IPA.Config.Config conf)
        {
            //Instance = this;
            Log = logger;
            Log.Info("PlatformCustomizer initialized.");
            //Instance = this;
            PluginConfig.Instance = conf.Generated<PluginConfig>();

            //menuPlatParent.name = "MenuPlatform";

            //SceneManager.activeSceneChanged += SceneManager_activeSceneChanged;

            zenject.Install<PCInstaller>(Location.StandardPlayer);
            zenject.Install<PCMenuInstaller>(Location.Menu);
        }

        private void SceneManager_activeSceneChanged(Scene arg0, Scene arg1)
        {
            if (arg1.name == "MainMenu" && isDone == false)
            {
                LoadScenes();
                try
                {
                    Object.Instantiate(menuPlatParent, new Vector3(0f, 0f, 0f), Quaternion.Euler(new Vector3(0f, 0f)));
                    Object.Instantiate(MenuPlat, new Vector3(0f, 0.01f, 0f), Quaternion.Euler(new Vector3(0f, 0f)), menuPlatParent.transform);
                    
                    return;
                }
                finally
                {
                    SceneManager.UnloadSceneAsync("BigMirrorEnvironment");
                }

            }
        }

        public bool isDone = false;

        public void LoadScenes()
        {
            SceneManager.LoadSceneAsync("BigMirrorEnvironment");
            new WaitForSecondsRealtime(0.1f);
            foreach (var platFinder in Resources.FindObjectsOfTypeAll<BloomFogEnvironment>())
            {
                if (platFinder.name == "Environment")
                {
                    MenuPlat = platFinder.transform.Find("PlayersPlace").gameObject;
                    for (int i = 0; i < 25; i++)
                    {
                        Log.Critical("oshefoihjioefhoihoeifhoehofhosef");
                    }
                    break;
                }
            }
        }
    }
}
