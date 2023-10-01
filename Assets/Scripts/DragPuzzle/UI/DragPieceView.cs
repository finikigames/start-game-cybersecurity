using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace DragPuzzle.UI {
    public class DragPieceView : MonoBehaviour, IDragHandler, IEndDragHandler {
        [SerializeField] private Image _piece;
        
        public string Index { get; set; }
        public bool IsLocked { get; set; }
        public Action<string> OnDropDrag { get; set; } 

        public void SetStartPosition(Vector2 position) {
            transform.localPosition = position;
        }

        public void OnDrag(PointerEventData eventData) {
            if (IsLocked) return;
            
            transform.Translate(eventData.delta);
        }

        public void OnEndDrag(PointerEventData eventData) {
            OnDropDrag?.Invoke(Index);
        }

        private void OnMouseDrag() {
            if (IsLocked) return;

            transform.position = Input.mousePosition;
        }
    }
}