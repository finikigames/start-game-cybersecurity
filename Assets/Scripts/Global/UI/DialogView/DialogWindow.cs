using System.Collections;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Global.UI.DialogView {
    public class DialogWindow : BaseWindow {
        public TextMeshProUGUI NameText;
        public TextMeshProUGUI ReplicaText;
        public VerticalLayoutGroup Group;
        
        public DialogConfig Config;

        public bool AllTextShowed;
        private Coroutine _coroutine;
        
        [SerializeField] private float _timeBetweenCharacters;
        
        public override async void Initialize(string id) {
            var data = Config.Data[id];

            NameText.text = data.Name;
            ReplicaText.text = data.Replica;
            AllTextShowed = false;

            _coroutine = StartCoroutine(TextVisible());
        }

        public void ShowAllText() {
            StopCoroutine(_coroutine);
            AllTextShowed = true;
            ReplicaText.maxVisibleCharacters = ReplicaText.text.Length;
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

            AllTextShowed = true;
        }
        
        
    }
}