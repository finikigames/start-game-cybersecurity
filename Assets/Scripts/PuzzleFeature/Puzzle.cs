using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace PuzzleFeature {
    public class Puzzle : MonoBehaviour {

        [SerializeField] private Button[] _buttons;
        [SerializeField] private GamePuzzle _puzzles;
        [SerializeField] private Transform _winBlock;

        public Action OnPuzzleWin;

        /*public GamePuzzle ChoosePuzzle(GamePuzzle[] puzzles) {
            return puzzles[Random.Range(0, puzzles.Length)];
        }*/

        public void FillPuzzle(Button v) {
            _winBlock.gameObject.SetActive(false);
            //ChoosePuzzle(puzzles).PickPuzzle(v);
            _puzzles.PickPuzzle(v);
        }

        public void StartPuzzle() {
            if (_buttons.Length == 0)
                return;
            foreach (var v in _buttons) {
                FillPuzzle(v);
            }

            _buttons[0].Select();
        }

        public void CheckWin() {
            int i = 0;
            int counter = 0;
            foreach (var v in _buttons) {
                if (v.image.sprite == _puzzles.Sprites[i++]) {
                    counter++;
                }
            }

            if (counter == _buttons.Length) {
                _winBlock.gameObject.SetActive(true);
                OnPuzzleWin?.Invoke();
            }
        }

        public void ChangePuzzleSprite(Button button) {
            int i = Array.IndexOf(_puzzles.Sprites, button.image.sprite);
            if (i == _puzzles.Sprites.Length - 1)
                i = -1;
            button.image.sprite = _puzzles.Sprites[++i];
        }

        public void SetNewPuzzle(GamePuzzle puzzle) {
            _puzzles = puzzle;
            StartPuzzle();
        }
    }
}