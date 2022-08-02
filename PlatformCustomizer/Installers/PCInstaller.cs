using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zenject;
using PlatformCustomizer.Configuration;
using PlatformCustomizer.UI.Settings;

namespace PlatformCustomizer
{
    public class PCInstaller : Installer
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<PlatformCustomizerController>().AsSingle();

        }
    }
}
