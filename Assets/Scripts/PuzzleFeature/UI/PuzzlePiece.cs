using System;
using UnityEngine;
using UnityEngine.UI;

namespace PuzzleFeature.UI {
    public class PuzzlePiece : MonoBehaviour {
        [SerializeField] private Button _pieceButton;
        
        public int Index { get; set; }
        public Sprite Piece {
            get => _pieceButton.image.sprite;
        }

        public void Initialize(Action<PuzzlePiece> action) {
            _pieceButton.onClick.RemoveAllListeners();
            _pieceButton.onClick.AddListener(() => action?.Invoke(this));
        }

        public void SetIcon(Sprite icon) {
            _pieceButton.image.sprite = icon;
        }

        public Vector2 GetPiecePos() {
            return gameObject.transform.localPosition;
        }
    }
}