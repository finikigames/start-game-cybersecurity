using UnityEngine;

namespace Global.UI {
    public abstract class BaseWindow : MonoBehaviour {
        protected abstract void Initialize(string id);

        public void Hide() {
            
        }
    }
}