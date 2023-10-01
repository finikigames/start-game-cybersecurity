using UnityEngine.UI;

namespace Global.Flow.Condition {
    public class InteractableButtonCondition : BaseCondition {
        public InteractableButtonCondition(Button clickButton) {
            clickButton.onClick.RemoveAllListeners();
            clickButton.onClick.AddListener(() => Ready = true);
        }

        public override void Check() {
            
        }
    }
}