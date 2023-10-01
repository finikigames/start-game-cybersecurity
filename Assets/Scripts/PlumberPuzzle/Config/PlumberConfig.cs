using System;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace PlumberPuzzle.Config {
    [Serializable]
    public class PlumberConfig {
        public VisualPipeData[] PipeDatas;
        public PipeType[] _PipeTypes;

        public int StartPos;
        public int EndPos;
        public int Columns;
        public int Rows;

        private Dictionary<PipeType, Sprite> _pipeInfos = new();

        public void Initialize() {
            _pipeInfos.Clear();
            
            foreach (VisualPipeData pipeData in PipeDatas) {
                _pipeInfos.Add(pipeData.Type, pipeData.PipeView);
            }
        }

        public Sprite GetPipeView(PipeType type) {
            return _pipeInfos[type];
        }
    }
}