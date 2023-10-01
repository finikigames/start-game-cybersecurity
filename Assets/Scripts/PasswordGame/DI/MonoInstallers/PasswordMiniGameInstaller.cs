using PasswordGame.Services;
using Zenject;

namespace PasswordGame.DI.MonoInstallers {
    public class PasswordMiniGameInstaller : MonoInstaller {
        public PasswordGameSceneSettings Settings;
        
        public override void InstallBindings() {
            Container
                .BindInterfacesAndSelfTo<LetterGeneratorService>()
                .AsSingle();

            Container
                .BindInstance(Settings)
                .AsSingle();

            Container
                .BindInterfacesAndSelfTo<MainPasswordService>()
                .AsSingle();
        }
    }
}