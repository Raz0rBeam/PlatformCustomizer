using System;
using BeatSaberMarkupLanguage;
using BeatSaberMarkupLanguage.Attributes;
using BeatSaberMarkupLanguage.Settings;
using Zenject;
using IPA;
using PlatformCustomizer.Configuration;

namespace PlatformCustomizer.UI.Settings
{
    [HotReload(RelativePathToLayout = @"..\Settings\SettingsHost")]
    [ViewDefinition("PlatformCustomizer.UI.Views.settings.bsml")]
    class SettingsHost : IInitializable, IDisposable
    {
        private PluginConfig _config = null!;

        [Init]
        private void Construct() => _config = PluginConfig.;

        [UIValue("enable")]
        public bool Enable
        {
            get => _config.EnableMod;
            set => _config.EnableMod = value;
        }

        public void Initialize()
        {
            BSMLSettings.instance.AddSettingsMenu("Platform Customizer", "PlatformCustomizer.UI.Views.settings.bsml", this);
        }
        
        public void Dispose()
        {
            if (BSMLParser.IsSingletonAvailable && BSMLSettings.instance != null)
                BSMLSettings.instance.RemoveSettingsMenu(this);
        }

    }
}
