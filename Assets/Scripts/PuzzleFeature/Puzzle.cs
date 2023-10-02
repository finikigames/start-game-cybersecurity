using System;
using Global.Flow.Condition;
using PuzzleFeature.Configs;
using PuzzleFeature.Flow;
using PuzzleFeature.UI;
using UnityEngine;
using Zenject;

namespace PuzzleFeature {
    public class Puzzle : MonoBehaviour, IInitializable {
        [SerializeField] private PuzzlePiece[] _pieces;
        [SerializeField] private GamePuzzleConfig puzzlesConfig;
        [SerializeField] private Transform _winBlock;
        [SerializeField] private Transform _selectedFrame;

        private PuzzlePiece _firstPiece;
        private int[] _checkPattern = new []{1,-1,3,-3};

        private FlowConditionService _flowConditionService;
        private SwapGameWinCondition _swapGameWinCondition;

        [Inject]
        public void Constructor(FlowConditionService flowConditionService) {
            _flowConditionService = flowConditionService;
        }
        
        private void Awake() {
            _swapGameWinCondition = new SwapGameWinCondition();
            _flowConditionService.RegisterCondition("swap_win_condition", _swapGameWinCondition);
            
            SetNewPuzzle(puzzlesConfig);
            _winBlock.gameObject.SetActive(false);
            _selectedFrame.gameObject.SetActive(false);

            for (var index = 0; index < _pieces.Length; index++) {
                var piece = _pieces[index];
                piece.Initialize(ChangePuzzleSprite);
                piece.Index = index;
            }
        }

        public void Initialize() {
            _swapGameWinCondition = new SwapGameWinCondition();
            _flowConditionService.RegisterCondition("swap_win_condition", _swapGameWinCondition);
        }

        private void StartPuzzle() {
            if (_pieces.Length == 0)
                return;
            
            puzzlesConfig.PrepareIcons();
            
            foreach (var piece in _pieces) {
                puzzlesConfig.PickPuzzle(piece);
            }
        }

        private void CheckWin() {
            var i = 0;
            var counter = 0;
            foreach (var v in _pieces) {
                if (v.Piece == puzzlesConfig.Sprites[i++]) {
                    counter++;
                }
            }

            if (counter != _pieces.Length) return;
            
            //_winBlock.gameObject.SetActive(true);
            _swapGameWinCondition.Ready = true;
        }

        private void ChangePuzzleSprite(PuzzlePiece piece) {
            if (_firstPiece == null) {
                _firstPiece = piece;
                _selectedFrame.gameObject.SetActive(true);
                _selectedFrame.transform.localPosition = _firstPiece.GetPiecePos();
                return;
            }

            if (_firstPiece == piece) {
                _selectedFrame.gameObject.SetActive(false);
                _firstPiece = null;
                return;
            }

            bool canChange = false;
            foreach (var check in _checkPattern) {
                if (_firstPiece.Index + check != piece.Index) continue;
                
                canChange = true;
            }
            
            if (!canChange) return;

            int i = Array.IndexOf(puzzlesConfig.Sprites, piece.Piece);
            piece.SetIcon(_firstPiece.Piece);
            _firstPiece.SetIcon(puzzlesConfig.Sprites[i]);
            
            _selectedFrame.gameObject.SetActive(false);
            _firstPiece = null;
            
            CheckWin();
        }

        private void SetNewPuzzle(GamePuzzleConfig puzzleConfig) {
            puzzlesConfig = puzzleConfig;
            StartPuzzle();
        }
    }
}