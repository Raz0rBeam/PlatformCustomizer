using UnityEngine;
using PlatformCustomizer;
using Zenject;

namespace PlatformCustomizer.Miscellaneous
{
    public class HateMulitplayer
    {
        public void Instantiate()
        {
            Plugin.instantiate.SetActive(false);
        }
    }
}
