using UnityEngine;

namespace Global.Flow.Condition {
    public class ScreenClickCondition : BaseCondition {
        public override void Check() {
            Ready = Input.GetMouseButtonDown(0);
        }
    }
}