using UnityEngine;
using UnityEngine.UI;

namespace DragPuzzle.UI {
    public class DragPuzzleGhostView : MonoBehaviour {
        [SerializeField] private Image _puzzleIcon;

        public void Initialize(Sprite sprite) {
            _puzzleIcon.sprite = sprite;
            _puzzleIcon.color = new Color(1f, 1f, 1f, 0.3f);
        }
    }
}