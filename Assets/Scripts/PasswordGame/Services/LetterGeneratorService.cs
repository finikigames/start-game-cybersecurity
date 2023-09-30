using PasswordGame.UI;
using UnityEngine;

namespace PasswordGame.Services {
    public class LetterGeneratorService {
        private readonly PasswordGameSceneSettings _sceneSettings;

        public LetterGeneratorService(PasswordGameSceneSettings sceneSettings) {
            _sceneSettings = sceneSettings;
        }
        
        public LetterView Get() {
            var prefab = _sceneSettings.LetterPrefab;

            return Object.Instantiate(prefab);
        }

        public void Release(GameObject obj) {
            Object.Destroy(obj);
        }
    }
}