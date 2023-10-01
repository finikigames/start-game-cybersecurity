using Main.Configs;
using Main.UI;
using UnityEngine;

namespace Main.Services {
    public class LetterGeneratorService {
        private readonly PasswordMiniGameConfig _config;

        public LetterGeneratorService(PasswordMiniGameConfig config) {
            _config = config;
        }
        
        public LetterView Get(RectTransform parent) {
            var prefab = _config.Prefab;

            return Object.Instantiate(prefab, parent);
        }

        public void Release(GameObject obj) {
            Object.Destroy(obj);
        }
    }
}