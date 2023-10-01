using TMPro;
using UnityEngine;

namespace Main.UI {
    public class LetterView : MonoBehaviour {
        public TextMeshProUGUI Text;
        public TextMeshProUGUI MainText;

        [HideInInspector]
        public bool Main;
        
        public void SetText(string text) {
            if (Main) {
                MainText.text = text;
            }
            else {
                Text.text = text;
            }
        }

        public void SetMainVisibility(bool main) {
            Main = main;
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