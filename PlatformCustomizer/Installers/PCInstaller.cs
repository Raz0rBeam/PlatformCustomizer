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
            Container.BindInterfacesAndSelfTo<TexChanger>().AsSingle();
        }
    }
}
