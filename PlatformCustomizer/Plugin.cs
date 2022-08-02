using IPA;
using IPA.Config;
using IPA.Config.Stores;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using IPALogger = IPA.Logging.Logger;
using SiraUtil.Zenject;
using PlatformCustomizer.Configuration;
using PlatformCustomizer.UI.Settings;

namespace PlatformCustomizer
{
    [Plugin(RuntimeOptions.SingleStartInit)]
    public class Plugin
    {
        internal static Plugin Instance { get; private set; }
        internal static IPALogger Log { get; private set; }
        

        [Init]
        public void Init(IPALogger logger, Zenjector zenject, Config conf)
        {
            Instance = this;
            Log = logger;
            Log.Info("PlatformCustomizer initialized.");
            Instance = this;
            PluginConfig.Instance = conf.Generated<PluginConfig>();
            
            zenject.Install<PCInstaller>(Location.StandardPlayer);
            zenject.Install(Location.Menu, Container => Container.BindInterfacesTo<SettingsHostFlowCoordinator>().AsSingle());


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
        }

        [OnEnable]
        public void OnEnable()
        {
            BsmlWrapper.EnableUI();
        }

        [OnDisable]
        public void OnDisable()
        {
            BsmlWrapper.DisableUI();
        }
    }
}
