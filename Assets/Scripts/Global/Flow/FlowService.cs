using Global.Flow.Condition;
using Zenject;

namespace Global.Flow {
    public class FlowService : IInitializable,
        ITickable {
        private readonly FlowSceneSettings _sceneSettings;
        private readonly MainFlowConfig _config;
        private readonly FlowConditionService _conditionService;

        private int _currentIndex;

        public FlowService(FlowSceneSettings sceneSettings,
            MainFlowConfig config,
            FlowConditionService conditionService) {
            _sceneSettings = sceneSettings;
            _config = config;
            _conditionService = conditionService;
        }

        public void Initialize() {

        }

        public void Tick() {
        }

        private void InitializeStep(FlowData data) {
            
        }
    }
}