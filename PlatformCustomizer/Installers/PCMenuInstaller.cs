using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zenject;
using PlatformCustomizer.UI.Settings;
using PlatformCustomizer.UI;
using PlatformCustomizer.Miscellaneous;
using PlatformCustomizer.MenuItems;
using PlatformCustomizer.CustomFeet;

namespace PlatformCustomizer
{
    public class PCMenuInstaller : Installer
    {
        public override void InstallBindings()
        {
            //Container.BindInterfacesAndSelfTo<MenuFloorManager>().AsCached();
           // Container.Bind<PlatformGrabber>().FromNewComponentOnNewGameObject().AsCached();
           Container.BindInterfacesTo<SettingsHostFlowCoordinator>().AsSingle();
           Container.BindInterfacesTo<SettingsHost>().AsSingle();
           Container.BindInterfacesAndSelfTo<TexChanger>().AsSingle();
        }
    }
}
