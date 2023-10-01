using PasswordGame.UI;
using UnityEngine;

namespace PasswordGame.Services {
    public class PasswordGameSceneSettings : MonoBehaviour {
        public GameObject GameRoot;
        public GameObject[] Lines;
        public GameObject LettersSpawnRoot;

        public LetterView LetterPrefab;
    }
}