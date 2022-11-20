using System;
using PlatformCustomizer.UI;
using BeatSaberMarkupLanguage.Attributes;
using BeatSaberMarkupLanguage.ViewControllers;
using PlatformCustomizer.Configuration;
using HMUI;


namespace PlatformCustomizer.UI.Settings
{

    [HotReload(RelativePathToLayout = @"../Views/settings")]
    [ViewDefinition("PlatformCustomizer.UI.Views.settings.bsml")]
    class SettingsHost : BSMLAutomaticViewController
    {
        PluginConfig config = PluginConfig.Instance;
        private bool isMuliplierDisabled;
        public string _warningText = "";

        [UIComponent("warning-text")]
        private readonly CurvedTextMeshPro warningText = null!;

        #region UIValues
        [UIValue("enable")]
        public bool Enable
        {
            get => config.EnableMod;
            set
            {
                config.EnableMod = value;
                NotifyPropertyChanged();
            }
        }

        [UIValue("platform-width")]
        public float PlatformWidth
        {
            get => config.PlatformWidth;
            set
            {
                config.PlatformWidth = value;
                NotifyPropertyChanged();
            }
        }

        [UIValue("platform-length")]
        public float PlatformLength
        {
            get => config.PlatformLength;
            set 
            {
                config.PlatformLength = value;
                NotifyPropertyChanged();
            }
        }

        [UIValue("enable-plat-ui")]
        public bool EnablePlatUI
        {
            get => config.MoveUIToPlatform;
            set
            {
                config.MoveUIToPlatform = value;
                NotifyPropertyChanged();
            }
        }

        [UIValue("ui-pos-x")]
        public float UIPosX
        {
            get => config.UIPositionX;
            set => config.UIPositionX = value;
        }

        [UIValue("ui-pos-y")]
        public float UIPosY
        {
            get => config.UIPositionY;
            set => config.UIPositionY = value;
        }

        [UIValue("energy-panel-distance")]
        public float EnergyPanelDistance
        {
            get => config.EnergyPanelDistance;
            set => config.EnergyPanelDistance = value;
        }

        [UIValue("enable-multiplier-anim")]
        public bool EnableMultiplier
        {
            get => config.DisableMultiplier;
            set => config.DisableMultiplier = value;
        }

        [UIValue("enable-feet")]
        public bool EnableFeet
        {
            get => config.Feet;
            set 
            {
                config.Feet = value;
                NotifyPropertyChanged();
            }
        }

        [UIValue("jordan-mode")]
        public bool JordanMode
        {
            get => config.JordanMode;
            set 
            {
                config.JordanMode = value;
                NotifyPropertyChanged();
            }
        }

        [UIValue("foot-scale")]
        public float FootScale
        {
            get => config.FootScale;
            set
            {
                config.FootScale = value;
                NotifyPropertyChanged();
            }
        }

        [UIValue("warning-text-text")]
        public string WarningText
        {
            get => _warningText;
            set
            {
                if (isMuliplierDisabled)
                {
                    _warningText = "WARNING!! Leaving 'Disable Multiplier' off may cause jumpscares!!";
                }
                else
                {
                    _warningText = "";
                }

            }

        }
        #endregion

        public string _WarningText()
        {
            string _warningText = "";
            if (config.MoveUIToPlatform && config.DisableMultiplier)
            {
                _warningText = "WARNING!! Leaving 'Disable Multiplier' off may cause jumpscares!!";
            }
            return _warningText;
        }
    }
}
