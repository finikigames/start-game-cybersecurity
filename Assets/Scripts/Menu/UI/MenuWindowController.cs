using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Menu.UI {
    public class MenuWindowController : MonoBehaviour {
        [SerializeField] private Button _playButton;

        private void Awake() {
            _playButton.onClick.RemoveAllListeners();
            _playButton.onClick.AddListener(() => LoadMainScene());
        }

        private void LoadMainScene() {
            SceneManager.LoadScene("PasswordMiniGame");
        }
    }
}