using System;
using UnityEngine;

namespace PuzzleFeature {
    public class Puzzle : MonoBehaviour {
        [SerializeField] private PuzzlePiece[] _pieces;
        [SerializeField] private GamePuzzle _puzzles;
        [SerializeField] private Transform _winBlock;
        [SerializeField] private Transform _selectedFrame;

        public Action OnPuzzleWin;

        private PuzzlePiece _firstPiece;
        private int[] _checkPattern = new []{1,-1,3,-3};

        private void Awake() {
            SetNewPuzzle(_puzzles);
            _winBlock.gameObject.SetActive(false);
            _selectedFrame.gameObject.SetActive(false);

            for (var index = 0; index < _pieces.Length; index++) {
                var piece = _pieces[index];
                piece.Initialize(ChangePuzzleSprite);
                piece.Index = index;
            }
        }

        private void StartPuzzle() {
            if (_pieces.Length == 0)
                return;
            
            _puzzles.PrepareIcons();
            
            foreach (var piece in _pieces) {
                _puzzles.PickPuzzle(piece);
            }
        }

        private void CheckWin() {
            var i = 0;
            var counter = 0;
            foreach (var v in _pieces) {
                if (v.Piece == _puzzles.Sprites[i++]) {
                    counter++;
                }
            }

            if (counter != _pieces.Length) return;
            
            _winBlock.gameObject.SetActive(true);
            OnPuzzleWin?.Invoke();
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

            int i = Array.IndexOf(_puzzles.Sprites, piece.Piece);
            piece.SetIcon(_firstPiece.Piece);
            _firstPiece.SetIcon(_puzzles.Sprites[i]);
            
            _selectedFrame.gameObject.SetActive(false);
            _firstPiece = null;
            
            CheckWin();
        }

        private void SetNewPuzzle(GamePuzzle puzzle) {
            _puzzles = puzzle;
            StartPuzzle();
        }
    }
}