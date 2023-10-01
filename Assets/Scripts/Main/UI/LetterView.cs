using TMPro;
using UnityEngine;

namespace Main.UI {
    public class LetterView : MonoBehaviour {
        public TextMeshProUGUI Text;
        public TextMeshProUGUI MainText;

        [HideInInspector]
        public bool Main;
        [HideInInspector]
        public bool Ready;

        public void SetText(string text) {
            Text.text = text;
        }

        public void SetMainVisibility(bool main) {
            if (main) {
                Text.gameObject.SetActive(false);
                MainText.gameObject.SetActive(true);
            }
            else {
                Text.gameObject.SetActive(true);
                MainText.gameObject.SetActive(false);
            }
        }
    }
}