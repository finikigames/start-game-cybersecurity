using System;
using System.Collections.Generic;
using DragPuzzle.Configs;
using DragPuzzle.Flow;
using DragPuzzle.UI;
using Global.Flow.Condition;
using UnityEngine;
using Zenject;

namespace DragPuzzle.Services {
    public class DragPuzzleService : IInitializable {
        private readonly DragPuzzleGameConfig _gameConfig;
        private readonly DragPuzzleField _puzzleField;
        private readonly FlowConditionService _flowConditionService;

        private DragGameWinCondition _condition;

        public DragPuzzleService(DragPuzzleGameConfig gameConfig,
                                 DragPuzzleField puzzleField
                                 ){//FlowConditionService flowConditionService) {
            _gameConfig = gameConfig;
            _puzzleField = puzzleField;
            //_flowConditionService = flowConditionService;
        } 
        public void Initialize() {
            _condition = new DragGameWinCondition();
            //_flowConditionService.RegisterCondition("drag_win_condition", _condition);
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

            _condition.Ready = true;
        }
    }
}