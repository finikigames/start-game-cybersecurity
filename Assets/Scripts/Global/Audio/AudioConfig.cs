using System;
using System.Collections.Generic;
using UnityEngine;

namespace Global.Audio {
    [Serializable]
    public class AudioConfig {
        public AudioData[] AudioData;

        private Dictionary<string, AudioClip> _audioClips = new();

        public void Initialize() {
            _audioClips.Clear();

            foreach (var data in AudioData) {
                _audioClips.Add(data.Id, data.Clip);
            }
        }

        public AudioClip GetClip(string id) {
            return _audioClips[id];
        }
    }
}