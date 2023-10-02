using UnityEngine.UI;

namespace Global.Flow.Condition {
    public class ContinueButtonCondition : BaseCondition {
        public ContinueButtonCondition(Button clickButton) {
            clickButton.onClick.RemoveAllListeners();
            clickButton.onClick.AddListener(() => Ready = true);
        }
        
        public override void Check() {
            
        }
    }
}