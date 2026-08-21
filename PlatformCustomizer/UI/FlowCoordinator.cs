using PlatformCustomizer.UI.Settings;
using HMUI;
using Zenject;
using BeatSaberMarkupLanguage;
using BeatSaberMarkupLanguage.MenuButtons;
using PlatformCustomizer.Configuration;

namespace PlatformCustomizer.UI
{
    public class SettingsHostFlowCoordinator : FlowCoordinator
    {
        PluginConfig config = PluginConfig.Instance;
        SettingsHost view = null;
        MainFlowCoordinator mainFlowCoordinator = null;

        [Inject]
        private void Construct(MainFlowCoordinator _mainFlowCoordinator, SettingsHost _settingsHost)
        {
            mainFlowCoordinator = _mainFlowCoordinator;
            view = _settingsHost;
        }

        protected override void DidActivate(bool firstActivation, bool addedToHierarchy, bool screenSystemEnabling)
        {
            SetTitle(nameof(PlatformCustomizer));
            showBackButton = true;

            ProvideInitialViewControllers(view);
        }
        protected override void BackButtonWasPressed(ViewController topViewController)
        {
            mainFlowCoordinator.DismissFlowCoordinator(this);
        }
    }
}
