using System;
using Global.Flow.Condition;
using UnityEngine.UI;
using Zenject;

namespace Global.UI.ContinueView {
    public class ContinueWindow : BaseWindow {
        private FlowConditionService _conditionService;
        
        public Button Button;
        private ContinueButtonCondition _continueButtonCondition;

        [Inject]
        private void Construct(FlowConditionService conditionService) {
            _conditionService = conditionService;
        }
        
        private void Start() {
            _continueButtonCondition = new ContinueButtonCondition(Button);
            _conditionService.RegisterCondition("continue_button_interaction", 
                _continueButtonCondition);
        }
        
        public override void Initialize(string id) {
        }

        private void OnDisable() {
            _continueButtonCondition.Ready = false;
        }
    }
}