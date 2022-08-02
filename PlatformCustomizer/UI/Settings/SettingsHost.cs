using System;
using BeatSaberMarkupLanguage;
using BeatSaberMarkupLanguage.Attributes;
using BeatSaberMarkupLanguage.Settings;
using BeatSaberMarkupLanguage.ViewControllers;
using BeatSaberMarkupLanguage.MenuButtons;
using HMUI;
using IPA;
using PlatformCustomizer.Configuration;
using UnityEngine;

namespace PlatformCustomizer.UI.Settings
{
    
    class SettingsHostFlowCoordinator : FlowCoordinator
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

                ProvideInitialViewControllers(view);

                /*
                maybe this can work one day :sadgeturd:
                var menuStand = GameObject.CreatePrimitive(PrimitiveType.Plane);
                position = new Vector3(0f, 0.1f, 0f);
                scale = new Vector3(0.3f, 1f, 0.2f);
                */
                 
            }
        }

        protected override void BackButtonWasPressed(ViewController topViewController)
        {
            BeatSaberUI.MainFlowCoordinator.DismissFlowCoordinator(this, null, ViewController.AnimationDirection.Vertical);
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

        [HotReload(RelativePathToLayout = @"..\Settings\SettingsHost")]
        [ViewDefinition("PlatformCustomizer.UI.Views.settings.bsml")]
        class SettingsHost : BSMLAutomaticViewController
        {
            PluginConfig config = PluginConfig.Instance;


            [UIValue("enable")]
            public bool Enable
            {
                get => config.EnableMod;
                set => config.EnableMod = value;

            }

            [UIValue("platform-width")]
            public float PlatformWidth
            {
                
                get => config.PlatformWidth;
                set => config.PlatformWidth = value;
            }

            [UIValue("platform-length")]
            public float PlatformLength
            {
                get => config.PlatformLength;
                set => config.PlatformLength = value;
            }

            [UIValue("enable-plat-ui")]
            public bool EnablePlatUI
            {
                get => config.MoveUIToPlatform;
                set => config.MoveUIToPlatform = value;
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
