using Main.Configs;
using UnityEngine;
using Zenject;

namespace Main.DI.ScriptableInstallers {
    [CreateAssetMenu(fileName = "PasswordMiniGameSettingsInstaller",
        menuName = "Installers/Password/PasswordMiniGameSettingsInstaller")]
    public class PasswordMiniGameSettingsInstaller : ScriptableObjectInstaller<PasswordMiniGameSettingsInstaller> {
        public PasswordMiniGameConfig Config;

        public override void InstallBindings() {
            Container
                .BindInstance(Config)
                .AsSingle();
        }
    }
}