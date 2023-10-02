using System;
using Global.Services;
using Global.UI;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace VoiceMessage.UI {
    public class VoiceMessageWindow : BaseWindow {
        [SerializeField] private Slider _voice;
        
        private AudioService _audioService;
        private bool _ready;

        [Inject]
        private void Construct(AudioService audioService) {
            _audioService = audioService;
        }
        
        public override void Initialize(string id) {
            _audioService.SetAdditionalSource("voice_message");
            _audioService.SetMainSourceVolume(0.1f);
            _ready = true;
        }

        public void Update() {
            if (!_ready) return;

            var percent = _audioService.GetAdditionalPercent();
            _voice.value = percent;
        }

        private void OnDisable() {
            _audioService.StopAdditionalSource();
            _audioService.SetMainSourceVolume(1f);
        }
    }
}