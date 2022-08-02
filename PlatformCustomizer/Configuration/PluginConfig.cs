using System.Runtime.CompilerServices;
using IPA.Config.Stores;
using UnityEngine;

[assembly: InternalsVisibleTo(GeneratedStore.AssemblyVisibilityTarget)]
namespace PlatformCustomizer.Configuration
{
    internal class PluginConfig {
        public static PluginConfig Instance;

        public virtual bool EnableMod { get; set; } = true;
        public virtual float PlatformWidth { get; set; } = 3;
        public virtual float PlatformLength { get; set; } = 3;
        public virtual bool MoveUIToPlatform { get; set; } = true;
        public virtual float UIPositionX { get; set; } = 2;
        public virtual float UIPositionY { get; set; } = 2;
    
    }
            
     

        
}