using UnityEngine;

namespace DragPuzzle.Configs {
    [CreateAssetMenu(menuName = "Content/DragPuzzle/DragPuzzleConfig")]
    public class DragPuzzleGameConfig : ScriptableObject {
        public float DropDistance;
        public Sprite[] Sprites;
    }
}