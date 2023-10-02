using UnityEngine.UI;

namespace Global.UI.StaticView {
    public class StaticWindow : BaseWindow {
        public Image Bg;       
        
        public StaticConfig Config;
        
        public override void Initialize(string id) {
            var data = Config.Data[id];

            Bg.sprite = data.Bg;
        }
    }
}