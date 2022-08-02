using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Zenject;
using SiraUtil.Logging;
using PlatformCustomizer.Configuration;

namespace PlatformCustomizer
{
    
    public class PlatformCustomizerController : IInitializable      
    {
        private PluginConfig _pluginConfig = null!;
        [Inject]
        private void Construct(PluginConfig pluginConfig)
        {
            _pluginConfig = pluginConfig;
        }

        
        static int x = 5;
        static int y = 5;
        static int z = 5;
        double glowx = x * 1.5;
        public Vector3 scaleChange;
        public Vector3 fgChange;

        


        public void Initialize()
        {
            if (_pluginConfig.EnableMod == true)
            {
                scaleChange = new Vector3(x, 1, z);
                fgChange = new Vector3((float)glowx, y, z);

                GameObject.Find("Mirror").transform.localScale = scaleChange;
                GameObject.Find("RectangleFakeGlow").transform.localScale = fgChange;
                GameObject.Find("Environment/PlayersPlace/Construction").transform.localScale = scaleChange;

                if (_pluginConfig.MoveUIToPlatform == true)
                {
                    GameObject.Find("BasicGameHUD").transform.position = new Vector3(0f, 7.01f, 0f);
                    GameObject.Find("BasicGameHUD").transform.Rotate(90f, 0f, 0f);
                    GameObject.Find("LeftPanel").transform.position = new Vector3(-6.5f, 0.01f, 2.78f);
                    GameObject.Find("RightPanel").transform.position = new Vector3(6.5f, 0.01f, 2.78f);
                    GameObject.Find("EnergyPanel").transform.position = new Vector3(0f, 0.01f, 4.5f);
                    return;
                }
                return;
            }
            
         
        }


    }
}
