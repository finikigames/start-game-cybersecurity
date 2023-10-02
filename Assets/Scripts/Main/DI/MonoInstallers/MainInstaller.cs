using Global.Audio;
using Global.Flow;
using Global.Flow.Condition;
using Global.Services;
using Main.Services;
using Zenject;

namespace Main.DI.MonoInstallers {
    public class MainInstaller : MonoInstaller {
        public FlowSceneSettings SceneSettings;
        public AudioSceneSettings AudioSettings;

        public override void InstallBindings() {
            Container
                .BindInstance(SceneSettings)
                .AsSingle();
            
            Container
                .BindInstance(AudioSettings)
                .AsSingle();
            
            Container
                .BindInterfacesAndSelfTo<FlowService>()
                .AsSingle();

            
            Container
                .BindInterfacesAndSelfTo<FlowConditionService>()
                .AsSingle();
            
            
            Container
                .BindInterfacesAndSelfTo<LetterGeneratorService>()
                .AsSingle();
            
            Container
                .BindInterfacesAndSelfTo<AudioService>()
                .AsSingle();
        }
    }
}