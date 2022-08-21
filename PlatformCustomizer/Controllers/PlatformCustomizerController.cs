using PlatformCustomizer.Configuration;
using UnityEngine;
using Zenject;
using BeatSaberMarkupLanguage;
using System.Reflection;
using System;
using PlatformCustomizer;

namespace PlatformCustomizer.Controllers
{
    public class PlatformCustomizerController : IInitializable
    {
        PluginConfig config = PluginConfig.Instance;
        
        public Vector3 scaleChange;
        public Vector3 fgChange;
        public Vector3 footScale;

        public void Initialize()
        {
            double xR = config.PlatformWidth;
            double zR = config.PlatformLength;
            double glowx = xR * 1.5;

            if (config.EnableMod == true)
            {
                scaleChange = new Vector3((float)xR, 1, (float)zR);
                fgChange = new Vector3((float)glowx, (float)zR, (float)zR);

                GameObject.Find("Mirror").transform.localScale = scaleChange;
                GameObject.Find("RectangleFakeGlow").transform.localScale = fgChange;
                GameObject.Find("Environment/PlayersPlace/Construction").transform.localScale = scaleChange;
                if (config.PlatformLength <= 1)
                {
                    if (config.PlatformWidth <= 1)
                    {
                        GameObject.Find("SaberBurnMarksArea").SetActive(false);
                        GameObject.Find("SaberBurnMarksParticles").SetActive(false);
                    }
                }
                //if you can make this better than two if statements please let me know.
                //using both and && made it think one was a float and the other was a bool, so here we are.

                var feet = GameObject.Find("Feet");
                if (config.Feet == false)
                {
                    feet.SetActive(false);
                }

                float fN = config.FootScale;
                footScale = new Vector3(fN, fN, fN);
                feet.transform.localScale = footScale;
                if (config.JordanMode == true)
                {
                    feet.transform.localScale = new Vector3(0f, 0f, 0f);
                    
                    Plugin.instantiate.SetActive(true);
                }

                var gameObject = GameObject.Find("BasicGameHUD") ?? GameObject.Find("NarrowGameHUD");

                if (config.DisableMultiplier == true)
                {
                    GameObject.Find("RightPanel/MultiplierCanvas").SetActive(false);
                    var mCanvas = gameObject.transform.Find("RightPanel/MultiplierCanvas");
                    var disableable = gameObject.transform.Find("RightPanel/RecordingPanel");
                    mCanvas.SetParent(disableable);
                }

                if (config.MoveUIToPlatform == true)
                {
                    double uIX = config.UIPositionX;
                    double uIY = config.UIPositionY;

                    if (gameObject != null)
                    {
                        gameObject.transform.position = new Vector3(0f, 7.01f, 0f);
                        gameObject.transform.Rotate(90f, 0f, 0f);
                        gameObject.transform.Find("LeftPanel").transform.position = new Vector3((float)-uIX, 0.01f, (float)uIY);
                        gameObject.transform.Find("RightPanel").transform.position = new Vector3((float)uIX, 0.01f, (float)uIY);

                        double x1 = (1 * config.PlatformLength) - 0.35;
                        gameObject.transform.Find("EnergyPanel").transform.position = new Vector3(0f, 0.01f, (float)x1);
                        return;
                    }
                }
            }
        }
    }
}
