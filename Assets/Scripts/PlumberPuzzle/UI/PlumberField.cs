using System;
using System.Collections.Generic;
using PlumberPuzzle.Config;
using UnityEngine;

namespace PlumberPuzzle.UI {
    public class PlumberField : MonoBehaviour {
        [SerializeField] private PipeView[] _pipes;

        private Dictionary<int, PipeView> _pipeCells = new();

        public void InitializePipe(Sprite icon, Action<int> callback, int cellIndex, PipeType type, int index) {
            _pipes[index].Initialize(icon, callback, cellIndex, type);
            _pipeCells.Add(cellIndex, _pipes[index]);
        }

        public void InitializeNull(int index) {
            _pipes[index].Hide();
        }

        public PipeView GetPipeData(int index) {
            return !_pipeCells.ContainsKey(index) ? null : _pipeCells[index];
        }
    }
}