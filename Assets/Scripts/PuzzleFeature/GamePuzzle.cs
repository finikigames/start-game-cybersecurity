using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

namespace PuzzleFeature {
    [CreateAssetMenu(menuName = "Content/GamePuzzle")]
    public class GamePuzzle : ScriptableObject {
        [SerializeField] private Sprite[] sprites;

        public Sprite[] Sprites {
            get {
                return sprites;
            }
        }

        public void PickPuzzle(Button button) {
            if (sprites.Length == 0)
                return;
            button.image.sprite = sprites[Random.Range(0, sprites.Length)];
        }
    }
}