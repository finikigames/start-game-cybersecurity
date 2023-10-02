using System;
using Global.Audio;
using Zenject;

namespace Global.Services {
    public class AudioService : IInitializable {
        private readonly AudioConfig _audioConfig;
        private readonly AudioSceneSettings _audioSettings;

        public AudioService(AudioConfig audioConfig,
                            AudioSceneSettings audioSettings) {
            _audioConfig = audioConfig;
            _audioSettings = audioSettings;
        }
        
        public void Initialize() {
            _audioConfig.Initialize();
        }

        public void SetGlobalSource(string id) {
            var clip = _audioConfig.GetClip(id);
            _audioSettings.GlobalSource.clip = clip;
            _audioSettings.GlobalSource.Play();
        }
        
        public void SetAdditionalSource(string id) {
            var clip = _audioConfig.GetClip(id);
            _audioSettings.AdditionalSource.clip = clip;
            _audioSettings.AdditionalSource.Play();
        }

        public void StopAdditionalSource() {
            _audioSettings.AdditionalSource.Stop();
        }

        public float GetClipLenght(string id) {
            return _audioConfig.GetClip(id).length;
        }
    }
}