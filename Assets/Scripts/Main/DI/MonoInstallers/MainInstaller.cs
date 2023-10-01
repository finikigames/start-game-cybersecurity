using Main.Services;
using Zenject;

namespace Main.DI.MonoInstallers {
    public class MainInstaller : MonoInstaller {
        public override void InstallBindings() {
            Container
                .BindInterfacesAndSelfTo<MainService>()
                .AsSingle();
        }
    }
}