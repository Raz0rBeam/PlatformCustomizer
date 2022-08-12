using IPA;
using IPA.Config;
using IPA.Config.Stores;
using IPALogger = IPA.Logging.Logger;
using SiraUtil.Zenject;
using PlatformCustomizer.Configuration;
using PlatformCustomizer.UI.Settings;
using HarmonyLib;
using System.Reflection;
using UnityEngine;
using System.Collections;
using System.IO;

namespace PlatformCustomizer
{
    [Plugin(RuntimeOptions.SingleStartInit)]
    public class Plugin
    {
        internal static Plugin Instance { get; private set; }
        internal static IPALogger Log { get; private set; }
        internal static Harmony harmony { get; private set; }
        

        [Init]
        public void Init(IPALogger logger, Zenjector zenject, Config conf)
        {
            Instance = this;
            Log = logger;
            Log.Info("PlatformCustomizer initialized.");
            Instance = this;
            PluginConfig.Instance = conf.Generated<PluginConfig>();
            PluginConfig config = PluginConfig.Instance;
            
            zenject.Install<PCInstaller>(Location.StandardPlayer);
            zenject.Install(Location.Menu, Container => Container.BindInterfacesTo<SettingsHostFlowCoordinator>().AsSingle());
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
    }
}
