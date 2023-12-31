﻿using Global.Flow.Condition;
using Global.Services;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Global.UI.InteractableView {
    public class InteractableWindow : BaseWindow {
        private FlowConditionService _conditionService;
        private AudioService _audioService;

        public Button Button;

        public InteractableConfig Config;
        private InteractableButtonCondition _interactableButtonCondition;

        [Inject]
        private void Construct(FlowConditionService conditionService,
                               AudioService audioService) {
            _conditionService = conditionService;
            _audioService = audioService;
        }
        
        private void Start() {
            _interactableButtonCondition = new InteractableButtonCondition(Button);
            _conditionService.RegisterCondition("button_interaction", 
                _interactableButtonCondition);
            
            Button.onClick.AddListener(() => {
                _audioService.SetAdditionalSource("click_sound");
            });
        }

        public override void Initialize(string id) {
            var data = Config.Data[id];

            var rectTransform = (RectTransform)Button.transform;

            if (data.ButtonSprite != null) {
                Button.image.sprite = data.ButtonSprite;
            }

            rectTransform.anchoredPosition = data.ButtonPosition;
            rectTransform.sizeDelta = data.ButtonSize;
        }

        private void OnDisable() {
            _interactableButtonCondition.Ready = false;
        }
    }
}