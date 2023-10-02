using System;
using System.Collections.Generic;
using UnityEngine;

namespace DragPuzzle.UI {
    public class DragPuzzleField : MonoBehaviour {
        [SerializeField] private DragPuzzleGhostView[] _views;
        [SerializeField] private DragPieceView[] _dragViews;
        
        private Dictionary<string, DragPuzzleGhostView> _ghostViews = new();
        private Dictionary<string, DragPieceView> _dragPuzzleViews = new();

        [SerializeField] private Transform _dragPuzzleBlock;
        [SerializeField] private Transform _dragLockedBlock;

        public void InitializeFieldView(Sprite[] sprites) {
            _ghostViews.Clear();
            
            for (var index = 0; index < _views.Length; index++) {
                var view = _views[index];
                var sprite = sprites[index];
                
                view.Initialize(sprite);
                _ghostViews.Add(sprite.name, view);
            }
        }

        public void InitializeDragViews(Action<string> callback, Sprite[] sprites) {
            _dragPuzzleViews.Clear();
            
            for (var index = 0; index < _dragViews.Length; index++) {
                var view = _dragViews[index];
                var sprite = sprites[index];

                view.Initialize(sprite, sprite.name);
                view.OnDropDrag = null;
                view.OnDropDrag += callback;
                view.transform.SetParent(_dragPuzzleBlock);
                
                _dragPuzzleViews.Add(sprite.name, view);
            }
        }

        public void SetPuzzleLock(string id) {
            var puzzle = _dragPuzzleViews[id];
            
            puzzle.SetLock();
            puzzle.transform.position = _ghostViews[id].transform.position;
            puzzle.transform.SetParent(_dragLockedBlock);
        }
        
        public Vector2 GetDragPuzzlePosition(string index) {
            return _dragPuzzleViews[index].transform.position;
        }

        public Vector2 GetGhostPosition(string index) {
            return _ghostViews[index].transform.position;
        }

        public bool CheckWin() {
            foreach (var dragPiece in _dragViews) {
                if (dragPiece.IsLocked) continue;

                return false;
            }

            return true;
        }
    }
}