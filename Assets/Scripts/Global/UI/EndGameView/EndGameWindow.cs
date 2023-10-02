using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Global.UI.EndGameView {
    public class EndGameWindow : BaseWindow {
        public Button Button;

        public override void Initialize(string id) {
            Button.onClick.RemoveAllListeners();
            Button.onClick.AddListener(() => SceneManager.LoadScene("Menu"));
        }
    }
}