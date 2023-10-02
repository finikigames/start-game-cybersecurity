using System;
using Global.Flow.Condition;
using TMPro;
using UnityEngine.UI;
using Zenject;

namespace Global.UI.ContinueView {
    public class ContinueWindow : BaseWindow {
        private FlowConditionService _conditionService;
        
        public Button Button;
        public TextMeshProUGUI ButtonText;
        public ContinueConfig Config;
        
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
            var data = Config.Data[id];

            ButtonText.color = data.Color;
        }

        private void OnDisable() {
            _continueButtonCondition.Ready = false;
        }
    }
}