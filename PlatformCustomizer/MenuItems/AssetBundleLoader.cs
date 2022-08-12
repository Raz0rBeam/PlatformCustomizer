using System.Collections;
using System.IO;
using UnityEngine;

namespace PlatformCustomizer.MenuItems
{
    public class AssetBundleLoader : MonoBehaviour
    {
        IEnumerator LoadAssetBundle()
        {
            AssetBundle loadedAssetBundle = AssetBundle.LoadFromFile(Path.Combine(Application.streamingAssetsPath, "menuplatform"));

            if (loadedAssetBundle == null)
            {
                Plugin.Log.Info("Failed to load menu platform bundle");
            }
            var prefab = loadedAssetBundle.LoadAsset<GameObject>("MirrorM");
            yield return prefab;

            
        }
        //void Instantiator() => Instantiate(prefab);

    }
}
