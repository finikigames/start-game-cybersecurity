using Global.Flow;
using UnityEngine;
using Zenject;

namespace Global.DI.ScriptableInstallers {
    [CreateAssetMenu(menuName = "Installers/Global/FlowScriptableInstaller", fileName = "FlowScriptableInstaller")]
    public class FlowScriptableInstaller : ScriptableObjectInstaller<FlowScriptableInstaller> {
        public MainFlowConfig Config;

        public override void InstallBindings() {
            Container
                .BindInstance(Config)
                .AsSingle();
        }
    }
}