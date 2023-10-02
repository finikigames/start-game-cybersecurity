using System;
using Global.Audio;
using Zenject;

namespace Global.Services {
    public class AudioService {
        private readonly AudioConfig _audioConfig;
        private readonly AudioSceneSettings _audioSettings;

        public AudioService(AudioConfig audioConfig,
                            AudioSceneSettings audioSettings) {
            _audioConfig = audioConfig;
            _audioSettings = audioSettings;
            _audioConfig.Initialize();
        }
        public void SetGlobalSource(string id, bool loop = false) {
            _audioSettings.GlobalSource.Stop();
            
            var clip = _audioConfig.GetClip(id);
            _audioSettings.GlobalSource.loop = !loop;
            _audioSettings.GlobalSource.clip = clip;
            
            _audioSettings.GlobalSource.Play();
        }

        public float GetAdditionalPercent() {
            var time = _audioSettings.AdditionalSource.time;

            var clipTime = _audioSettings.AdditionalSource.clip.length;

            return time / clipTime;
        }
        
        public void SetAdditionalSource(string id, bool muteMain = false) {
            _audioSettings.AdditionalSource.Stop();
            var clip = _audioConfig.GetClip(id);
            _audioSettings.AdditionalSource.clip = clip;
            _audioSettings.AdditionalSource.Play();

            if (muteMain) {
                _audioSettings.GlobalSource.volume = 0.1f;
            }
        }

        public void SetMainSourceVolume(float volume) {
            _audioSettings.GlobalSource.volume = volume;
        }

        public void StopAdditionalSource() {
            _audioSettings.AdditionalSource.Stop();
        }

        public float GetClipLenght(string id) {
            return _audioConfig.GetClip(id).length;
        }
    }
}