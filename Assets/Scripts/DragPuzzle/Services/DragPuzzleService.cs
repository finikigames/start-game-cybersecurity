using System;
using System.Collections.Generic;
using DragPuzzle.Configs;
using DragPuzzle.UI;
using UnityEngine;
using Zenject;

namespace DragPuzzle.Services {
    public class DragPuzzleService : IInitializable {
        private readonly DragPuzzleGameConfig _gameConfig;
        private readonly DragPuzzleField _puzzleField;
        
        public Action OnDragPuzzleWin { get; set; }

        public DragPuzzleService(DragPuzzleGameConfig gameConfig,
                                 DragPuzzleField puzzleField) {
            _gameConfig = gameConfig;
            _puzzleField = puzzleField;
        } 
        public void Initialize() {
            var sprites = _gameConfig.Sprites;
            
            _puzzleField.InitializeFieldView(sprites);
            _puzzleField.InitializeDragViews(Check, sprites);
        }
        
        private void Check(string id) {
            Vector2 from = _puzzleField.GetDragPuzzlePosition(id);
            Vector2 to = _puzzleField.GetGhostPosition(id);
            var distance = Vector3.Distance(from, to);

            if (!(distance < _gameConfig.DropDistance)) return;
            
            _puzzleField.SetPuzzleLock(id);
            if (!_puzzleField.CheckWin()) return;
            
            OnDragPuzzleWin?.Invoke();
            Debug.Log("You win drag puzzle game!!!");
        }
    }
}