using Global.Flow.Condition;
using Global.Services;
using Global.UI.DialogView;
using UnityEngine;
using Zenject;

namespace Global.Flow {
    public class FlowService : IInitializable,
                               ITickable {
        private readonly FlowSceneSettings _sceneSettings;
        private readonly MainFlowConfig _config;
        private readonly FlowConditionService _conditionService;
        private readonly AudioService _audioService;

        private int _currentIndex;
        private FlowStep _lastStep;

        public FlowService(FlowSceneSettings sceneSettings,
                           MainFlowConfig config, 
                           FlowConditionService conditionService,
                           AudioService audioService) {
            _sceneSettings = sceneSettings;
            _config = config;
            _conditionService = conditionService;
            _audioService = audioService;
        }

        public void Initialize() {
            _lastStep = _config.MainFlowSteps[_currentIndex];

            foreach (var data in _lastStep.Data) {
                if (!string.IsNullOrEmpty(_lastStep.AudioId)) {
                    if (_lastStep.MainSound) {
                        _audioService.SetGlobalSource(_lastStep.AudioId); 
                    }
                    else {
                        _audioService.SetAdditionalSource(_lastStep.AudioId);
                    }
                }
                InitializeStep(data);
            }
        }

        public void Tick() {
            if (_lastStep != null && _conditionService.CheckConditions(_lastStep.Condition)) {
                bool hasDialog = false;

                foreach (var data in _lastStep.Data) {
                    if (data.Window == "dialog_window") {
                        hasDialog = true;
                    }
                }

                bool hasScreenClick = false;

                foreach (var condition in _lastStep.Condition) {
                    if (condition == "screen_click") {
                        hasScreenClick = true;
                    }
                }

                if (hasDialog && hasScreenClick) {
                    var window = (DialogWindow)_sceneSettings.Windows["dialog_window"];
                    if (!window.AllTextShowed) {
                        window.ShowAllText();
                        return;
                    }
                }
                
                DisposeStep(_lastStep);

                _currentIndex++;
                _lastStep = null;
            }

            if (_lastStep != null) return;

            if (_config.MainFlowSteps.Count <= _currentIndex) return;
            _lastStep = _config.MainFlowSteps[_currentIndex];

            foreach (var data in _lastStep.Data) {
                if (!string.IsNullOrEmpty(_lastStep.AudioId)) {
                    if (_lastStep.MainSound) {
                       _audioService.SetGlobalSource(_lastStep.AudioId); 
                    }
                    else {
                        _audioService.SetAdditionalSource(_lastStep.AudioId);
                    }
                }
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