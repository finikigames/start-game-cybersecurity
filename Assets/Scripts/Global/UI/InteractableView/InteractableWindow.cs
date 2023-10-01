﻿using System;
using Global.Flow.Condition;
using UnityEngine.UI;
using Zenject;

namespace Global.UI.InteractableView {
    public class InteractableWindow : BaseWindow {
        private FlowConditionService _conditionService;
        
        public Button Button;

        public InteractableConfig Config;
        private InteractableButtonCondition _interactableButtonCondition;

        [Inject]
        private void Construct(FlowConditionService conditionService) {
            _conditionService = conditionService;
        }
        
        private void Start() {
            _interactableButtonCondition = new InteractableButtonCondition(Button);
            _conditionService.RegisterCondition("button_interaction", 
                _interactableButtonCondition);
        }

        public override void Initialize(string id) {
            
        }

        private void OnDisable() {
            _interactableButtonCondition.Ready = false;
        }
    }
}