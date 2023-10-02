using Global.Flow.Condition;
using Zenject;

namespace Global.Flow {
    public class FlowService : IInitializable,
                               ITickable {
        private readonly FlowSceneSettings _sceneSettings;
        private readonly MainFlowConfig _config;
        private readonly FlowConditionService _conditionService;

        private int _currentIndex;
        private FlowStep _lastStep;

        public FlowService(FlowSceneSettings sceneSettings,
                           MainFlowConfig config, 
                           FlowConditionService conditionService) {
            _sceneSettings = sceneSettings;
            _config = config;
            _conditionService = conditionService;
        }

        public void Initialize() {
            _lastStep = _config.MainFlowSteps[_currentIndex];

            foreach (var data in _lastStep.Data) {
                InitializeStep(data);
            }
        }

        public void Tick() {
            if (_lastStep != null && _conditionService.CheckConditions(_lastStep.Condition)) {
                DisposeStep(_lastStep);

                _currentIndex++;
                _lastStep = null;
            }

            if (_lastStep != null) return;

            if (_config.MainFlowSteps.Count <= _currentIndex) return;
            _lastStep = _config.MainFlowSteps[_currentIndex];

            foreach (var data in _lastStep.Data) {
                InitializeStep(data);
            }
        }

        private void InitializeStep(FlowData data) {
            var window = _sceneSettings.Windows[data.Window];

            window.Show();
            window.Initialize(data.DataId);
        }

        private void DisposeStep(FlowStep step) {
            foreach (var data in step.Data) {
                var window = _sceneSettings.Windows[data.Window];

                window.Hide();
            }
        }
    }
}