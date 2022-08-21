using IPA;
using IPA.Config.Stores;
using IPALogger = IPA.Logging.Logger;
using SiraUtil.Zenject;
using PlatformCustomizer.Configuration;
using PlatformCustomizer.UI;
using UnityEngine;
using UnityEngine.SceneManagement;
using HarmonyLib;
using System.Reflection;
using BeatSaberMarkupLanguage;

namespace PlatformCustomizer
{
    [Plugin(RuntimeOptions.SingleStartInit)]
    public class Plugin
    {
        internal static Plugin Instance { get; private set; }
        internal static IPALogger Log { get; private set; }
        internal static Harmony harmony { get; private set; }
        public GameObject feet = GameObject.Find("Feet");
        public GameObject _gameObject;
        public Object _jordans; 

        [Init]
        public void Init(IPALogger logger, Zenjector zenject, IPA.Config.Config conf, Location location, SceneManager sceneManager)
        {
            Instance = this;
            Log = logger;
            Log.Info("PlatformCustomizer initialized.");
            Instance = this;
            PluginConfig.Instance = conf.Generated<PluginConfig>();
            PluginConfig config = PluginConfig.Instance;

            SceneManager.activeSceneChanged += SceneManager_activeSceneChanged; 

            zenject.Install<PCInstaller>(Location.StandardPlayer);
            zenject.Install<PCMenuInstaller>(Location.Menu);

            #region Yippee!
            Log.Info("Yippee!");
            Log.Info("Yippee!");
            Log.Info("Yippee!");
            Log.Info("Yippee!");
            int numberRaw = new System.Random().Next(1, 5);
            string number = numberRaw.ToString();
            if (numberRaw == 2)
            {
                Log.Info("WAHHHHH");
            }
            else
            {
                Log.Info("Yippee!");
            }
            #endregion
        }

        private void SceneManager_activeSceneChanged(Scene arg0, Scene arg1)
        {
            if (arg1.name == "MainMenu" && isDone == false)
            {
                LoadAssets();
            }
        }

        [OnStart]
        public void OnApplicationStart()
        {
            harmony = new Harmony("com.Raz0rBeam.PlatformCustomizer");
            harmony.PatchAll(Assembly.GetExecutingAssembly());

            BsmlWrapper.EnableUI();
        }

        [OnExit]
        public void OnApplicationExit()
        {
            harmony.UnpatchSelf();

            BsmlWrapper.DisableUI();
        }

        public AssetBundle loadedAssetBundle = AssetBundle.LoadFromMemory(Utilities.GetResource(Assembly.GetExecutingAssembly(), "PlatformCustomizer.Assets.jordans"));
        public bool isDone = false;
        public static GameObject instantiate;
        public void LoadAssets()
        {
            _gameObject = loadedAssetBundle.LoadAsset<GameObject>("Jordans");
            instantiate = Object.Instantiate(_gameObject);
            Object.DontDestroyOnLoad(instantiate);
            instantiate.name = "shoes";
            instantiate.transform.position = new Vector3(0f, 0.05f, 0f);
            instantiate.transform.localScale = new Vector3(1.2f, 1.2f, 1.2f);
            instantiate.SetActive(false);
            isDone = true;
        }
    }
}
