using System;
using Global.Services;
using Global.UI;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace VoiceMessage.UI {
    public class VoiceMessageWindow : BaseWindow, ITickable {
        [SerializeField] private Slider _voice;
        
        private readonly AudioService _audioService;
        private bool _ready;
        private float _startedTime;
        private float _lenght;

        public VoiceMessageWindow(AudioService audioService) {
            _audioService = audioService;
        }
        
        public override void Initialize(string id) {
            _lenght = _audioService.GetClipLenght("voice_message");
            _voice.minValue = 0;
            _voice.maxValue = _lenght;
            _voice.value = 0f;
            _startedTime = (float)(DateTime.UtcNow - new DateTime(1970, 1, 1)).TotalSeconds;

            _audioService.SetAdditionalSource("voice_message");
            _ready = true;
        }

        public void Tick() {
            if (!_ready) return;
            
            var nowTime = (float)(DateTime.UtcNow - new DateTime(1970, 1, 1)).TotalSeconds;
            var passedTime = nowTime - _startedTime;
            if (passedTime > _lenght) {
                _ready = false;
                return;
            }

            _voice.value = passedTime;
        }
    }
}