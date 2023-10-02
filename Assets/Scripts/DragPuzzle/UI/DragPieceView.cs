using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace DragPuzzle.UI {
    public class DragPieceView : MonoBehaviour, IDragHandler, IEndDragHandler {
        [SerializeField] private Image _piece;

        private string _index;

        public Action<string> OnDropDrag { get; set; }
        public bool IsLocked { get; private set; }

        public void Initialize(Sprite pieceSprite, string index) {
            _piece.sprite = pieceSprite;
            _piece.color = new Color(0.75f, 0.75f, 0.75f, 0.92f);
            _piece.SetNativeSize();
            _index = index;
            IsLocked = false;
            //transform.localPosition = startPosition;
        }

        public void SetLock() {
            IsLocked = true;
            _piece.color = Color.white;
        }

        public void OnDrag(PointerEventData eventData) {
            if (IsLocked) return;
            
            transform.Translate(eventData.delta);
        }

        public void OnEndDrag(PointerEventData eventData) {
            if (IsLocked) return;
            
            OnDropDrag?.Invoke(_index);
        }

        private void OnMouseDrag() {
            if (IsLocked) return;

            transform.position = Input.mousePosition;
        }
    }
}