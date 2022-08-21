using Zenject;
using UnityEngine;
using PlatformCustomizer.Configuration;

namespace PlatformCustomizer.MenuItems
{
    public class DisableItems : IInitializable
    {
        PluginConfig config = PluginConfig.Instance;
        public GameObject feet = GameObject.Find("Feet");
        public GameObject jordans = GameObject.Find("shoes");

        public void Initialize()
        {

            /*if (config.EnableMod == true)
            {
                if (config.JordanMode == true)
                {
                    feet.SetActive(false);
                    Plugin.instantiate.SetActive(true);
                }
            }*/
        }
    }
}
