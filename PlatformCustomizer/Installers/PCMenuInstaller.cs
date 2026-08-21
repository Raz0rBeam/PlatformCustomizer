using Zenject;
using PlatformCustomizer.UI.Settings;
using PlatformCustomizer.UI;
using PlatformCustomizer.CustomFeet;
using PlatformCustomizer.Managers;

namespace PlatformCustomizer
{
    public class PCMenuInstaller : Installer
    {
        public override void InstallBindings()
        {
           Container.Bind<SettingsHostFlowCoordinator>().FromNewComponentOnNewGameObject().AsSingle();
           Container.Bind<SettingsHost>().FromNewComponentAsViewController().AsSingle();
           Container.BindInterfacesAndSelfTo<TexChanger>().AsSingle();
           Container.BindInterfacesTo<MenuButtonManager>().AsSingle();
        }
    }
}
