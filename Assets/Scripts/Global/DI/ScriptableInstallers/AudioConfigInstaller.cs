using Global.Audio;
using UnityEngine;
using Zenject;

namespace Global.DI.ScriptableInstallers {
    [CreateAssetMenu(menuName = "Installers/Global/AudioConfigInstaller", fileName = "AudioConfigInstaller")]
    public class AudioConfigInstaller : ScriptableObjectInstaller<AudioConfigInstaller>{
        public AudioConfig AudioConfig;
        
        public override void InstallBindings() {
            Container
                .BindInstance(AudioConfig)
                .AsSingle();
        }
    }
}