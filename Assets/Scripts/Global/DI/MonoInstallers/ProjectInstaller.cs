using Global.Flow.Condition;
using Zenject;

namespace Global.DI.MonoInstallers {
    public class ProjectInstaller : MonoInstaller {
        public override void InstallBindings() {
            Container
                .BindInterfacesAndSelfTo<FlowConditionService>()
                .AsSingle();
        }
    }
}