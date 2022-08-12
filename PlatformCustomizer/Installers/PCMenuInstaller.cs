using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zenject;
using PlatformCustomizer.Configuration;
using PlatformCustomizer.UI.Settings;
using PlatformCustomizer.MenuItems;

namespace PlatformCustomizer
{
    public class PCMenuInstaller : Installer
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<MenuFloorManager>().AsSingle();
        }
    }
}
