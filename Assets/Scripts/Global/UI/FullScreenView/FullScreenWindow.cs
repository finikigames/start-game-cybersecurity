using TMPro;

namespace Global.UI.FullScreenView {
    public class FullScreenWindow : BaseWindow {
        public TextMeshProUGUI Text;

        public FullScreenConfig Config;
        
        public override void Initialize(string id) {
            var data = Config.Data[id];

            Text.text = data.Text;
        }
    }
}