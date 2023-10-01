﻿using PasswordGame.Configs;
using UnityEngine;
using Zenject;

namespace PasswordGame.DI.ScriptableInstallers {
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