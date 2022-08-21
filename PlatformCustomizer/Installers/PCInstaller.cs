using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zenject;
using IPA;
using PlatformCustomizer.Controllers;
using PlatformCustomizer.CustomFeet;

namespace PlatformCustomizer
{
    public class PCInstaller : Installer
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<PlatformCustomizerController>().AsSingle();
            BindRemoteJordans();
        }

        private void BindRemoteJordans()
        {
            BindJordans(new RemoteLocation.InitData
            {
                Name = "menuplatform",
                RemoteLocation = "https://github.com/Raz0rBeam/PlatformCustomizer/blob/master/PlatformCustomizer/Assets/menuplatform?raw=true",
                Filename = "menuplatform",
            });
        }

        private void BindJordans(RemoteLocation.InitData data)
        {
            Container.Bind<RemoteLocation>().To<RemoteLocation>().AsCached().WithArguments(data);
        }
    }
}
