using UnityEngine;

namespace Global.UI {
    public abstract class BaseWindow : MonoBehaviour {
        public abstract void Initialize(string id);

        public void Show() {
            gameObject.SetActive(true);
        }
        
        public void Hide() {
            gameObject.SetActive(false);
        }
    }
}