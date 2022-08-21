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

        protected override void DidActivate(bool firstActivation, bool addedToHeirarchy, bool screenSystemEnabling)
        {
            if (firstActivation)
            {
                SetTitle("Platform Customizer");
                showBackButton = true;

                if (view == null)
                    view = BeatSaberUI.CreateViewController<SettingsHost>();

                //GameObject.Find("MenuPlatform").SetActive(true);

                ProvideInitialViewControllers(view);
            }

        }

        protected override void BackButtonWasPressed(ViewController topViewController)
        {
            BeatSaberUI.MainFlowCoordinator.DismissFlowCoordinator(this, null, ViewController.AnimationDirection.Vertical);
            //GameObject.Find("MenuPlatform").SetActive(false);
        }

        public void ShowFlow()
        {
            var _parentFlow = BeatSaberUI.MainFlowCoordinator.YoungestChildFlowCoordinatorOrSelf();

            BeatSaberUI.PresentFlowCoordinator(_parentFlow, this);
        }

        static SettingsHostFlowCoordinator flow = null;
        static MenuButton button;

        public static void Deinit()
        {
            if (button != null)
                MenuButtons.instance.UnregisterButton(button);
        }

        public static void Initialize()
        {
            MenuButtons.instance.RegisterButton(button ??= new MenuButton("Platform Customizer", "I Barely Even Know Her!", () =>
            {
                if (flow == null)
                    flow = BeatSaberUI.CreateFlowCoordinator<SettingsHostFlowCoordinator>();


                flow.ShowFlow();
            }, true));
        }
    }
    public class BsmlWrapper
    {
        static readonly bool hasBsml = IPA.Loader.PluginManager.GetPluginFromId("BeatSaberMarkupLanguage") != null;

        public static void EnableUI()
        {
            void wrap() => SettingsHostFlowCoordinator.Initialize();

            if (hasBsml)
                wrap();
        }
        public static void DisableUI()
        {
            void wrap() => SettingsHostFlowCoordinator.Deinit();

            if (hasBsml)
                wrap();
        }
    }
}
