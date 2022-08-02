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
using IPA.Logging;

namespace PlatformCustomizer
{
    
    public class PlatformCustomizerController : IInitializable      
    {
        PluginConfig config = PluginConfig.Instance;
        
        public Vector3 scaleChange;
        public Vector3 fgChange;
        

        


        public void Initialize()
        {
            double xR = config.PlatformWidth;
            double zR = config.PlatformLength;
            float y = 1;
            double glowx = xR * 1.5;
            if (config.EnableMod == true)
            {

                scaleChange = new Vector3((float)xR, 1, (float)zR);
                fgChange = new Vector3((float)glowx, (float)zR, (float)zR);

                GameObject.Find("Mirror").transform.localScale = scaleChange;
                GameObject.Find("RectangleFakeGlow").transform.localScale = fgChange;
                GameObject.Find("Environment/PlayersPlace/Construction").transform.localScale = scaleChange;


                //GameObject.Find("RectangleFakeGlow")

                if (config.MoveUIToPlatform == true)
                {
                    double uIX = config.UIPositionX;
                    double uIY = config.UIPositionY;


                    GameObject.Find("BasicGameHUD").transform.position = new Vector3(0f, 7.01f, 0f);
                    GameObject.Find("BasicGameHUD").transform.Rotate(90f, 0f, 0f);
                    GameObject.Find("LeftPanel").transform.position = new Vector3((float)-uIX, 0.01f, (float)uIY);
                    GameObject.Find("RightPanel").transform.position = new Vector3((float)uIX, 0.01f, (float)uIY);

                    GameObject.Find("NarrowGameHUD").transform.position = new Vector3(0f, 7.01f, 0f);
                    GameObject.Find("NarrowGameHUD").transform.Rotate(90f, 0f, 0f);
                    GameObject.Find("Environment/NarrowGameHUD/LeftPanel").transform.position = new Vector3((float)-uIX, 0.01f, (float)uIY);
                    GameObject.Find("Environment/NarrowGameHUD/RightPanel").transform.position = new Vector3((float)uIX, 0.01f, (float)uIY);

                    double x1 = (1 * config.PlatformLength) - 0.35;
                    GameObject.Find("EnergyPanel").transform.position = new Vector3(0f, 0.01f, (float)x1);
                    return;
                }
                return;
            }
            
         
        }


    }
}
