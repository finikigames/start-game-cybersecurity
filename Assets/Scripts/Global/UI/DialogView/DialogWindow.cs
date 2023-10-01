using System.Collections;
using TMPro;
using UnityEngine;

namespace Global.UI.DialogView {
    public class DialogWindow : BaseWindow {
        public TextMeshProUGUI NameText;
        public TextMeshProUGUI ReplicaText;
        
        public DialogConfig Config;

        [SerializeField] private float _timeBetweenCharacters;
        
        public override void Initialize(string id) {
            var data = Config.Data[id];

            NameText.text = data.Name;
            ReplicaText.text = data.Replica;

            StartCoroutine(TextVisible());
        }
        
        private IEnumerator TextVisible() {
            ReplicaText.ForceMeshUpdate();
            int totalVisibleCharacters = ReplicaText.textInfo.characterCount;
            int counter = 0;

            while (true) {
                int visibleCount = counter % (totalVisibleCharacters + 1);
                ReplicaText.maxVisibleCharacters = visibleCount;

                if (visibleCount >= totalVisibleCharacters) {
                    break;
                }

                counter += 1;
                yield return new WaitForSeconds(_timeBetweenCharacters);
            }
        }
    }
}