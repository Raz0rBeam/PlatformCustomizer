using Zenject;
using PlatformCustomizer.Miscellaneous;

namespace PlatformCustomizer.Installers
{
    public class MultiplayerKiller : Installer
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<HateMulitplayer>().AsSingle();
        }
    }
}
