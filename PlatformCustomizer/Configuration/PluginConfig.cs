using System.Runtime.CompilerServices;
using IPA.Config.Stores;
using UnityEngine;

[assembly: InternalsVisibleTo(GeneratedStore.AssemblyVisibilityTarget)]
namespace PlatformCustomizer.Configuration
{
    internal class PluginConfig
    {
        public virtual bool EnableMod { get; set; } = true;
        public virtual bool MoveUIToPlatform { get; set; } = true;
        
    }
}