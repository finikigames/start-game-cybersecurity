using Global.Flow;
using Global.Flow.Condition;
using Main.Services;
using Zenject;

namespace Main.DI.MonoInstallers {
    public class MainInstaller : MonoInstaller {
        public FlowSceneSettings SceneSettings;

        public override void InstallBindings() {
            Container
                .BindInstance(SceneSettings)
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
        }
    }
}