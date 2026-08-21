using System;
using BeatSaberMarkupLanguage;
using BeatSaberMarkupLanguage.MenuButtons;
using PlatformCustomizer.UI;
using Zenject;

namespace PlatformCustomizer.Managers
{
    internal class MenuButtonManager : IInitializable, IDisposable
    {
        private readonly MenuButtons menuButtons;
        private readonly MenuButton menuButton;
        private readonly MainFlowCoordinator mainFlowCoordinator;
        private readonly SettingsHostFlowCoordinator SHFlowCoordinator;

        public MenuButtonManager(MainFlowCoordinator _mainFlowCoordinator, SettingsHostFlowCoordinator _SHFC, MenuButtons menuButtons)
        {
            this.menuButtons = menuButtons;
            menuButton = new MenuButton(nameof(PlatformCustomizer), "Customize the platform!", MenuButtonClicked);
            mainFlowCoordinator = _mainFlowCoordinator;
            SHFlowCoordinator = _SHFC;

        }

        public void Initialize()
        {
            menuButtons.RegisterButton(menuButton);
        }

        public void Dispose()
        {
            menuButtons.UnregisterButton(menuButton);
        }

        private void MenuButtonClicked()
        {
            mainFlowCoordinator.PresentFlowCoordinator(SHFlowCoordinator);
        }
    }
}
