using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

namespace PuzzleFeature {
    [CreateAssetMenu(menuName = "Content/GamePuzzle")]
    public class GamePuzzle : ScriptableObject {
        [SerializeField] private Sprite[] sprites;

        private List<Sprite> _spritesList = new();

        public Sprite[] Sprites {
            get {
                return sprites;
            }
        }

        public void PrepareIcons() {
            _spritesList.Clear();
            foreach (var sprite in sprites) {
                _spritesList.Add(sprite);
            }
        }

        public void PickPuzzle(PuzzlePiece button) {
            if (sprites.Length == 0) return;
            
            var index = Random.Range(0, _spritesList.Count);
            var icon = _spritesList[index];
            button.SetIcon(icon);
            _spritesList.RemoveAt(index);
        }
    }
}