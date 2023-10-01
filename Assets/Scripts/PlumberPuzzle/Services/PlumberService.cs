using System;
using PlumberPuzzle.Config;
using PlumberPuzzle.UI;
using UnityEngine;
using Zenject;

namespace PlumberPuzzle.Services {
    public class PlumberService : IInitializable {
        private readonly PlumberConfig _plumberConfig;
        private readonly PlumberField _field;
        
        public Action OnPlumberWin { get; set; }

        public PlumberService(PlumberConfig plumberConfig,
                              PlumberField field) {
            _plumberConfig = plumberConfig;
            _field = field;
        }
        
        public void Initialize() {
            _plumberConfig.Initialize();

            var column = 0;
            var row = 0;
            for (var index = 0; index < _plumberConfig._PipeTypes.Length; index++) {
                if ((++column % 10) == _plumberConfig.Columns - 1) {
                    row++;
                    column = 0;
                }
                
                var pipeType = _plumberConfig._PipeTypes[index];
                var pipeIcon = _plumberConfig.GetPipeView(pipeType);
                var cellIndex = row * 10 + column;
                
                _field.InitializePipe(pipeIcon, RotatePipe, cellIndex, pipeType, index);
            }
        }

        private void RotatePipe(int index) {
            var pipe = _field.GetPipeData(index);
            
            pipe.RotatePipe();
            var pipeData = pipe.Data;

            if (pipeData.ConnectionType == PipeType.Line) {
                
                return;
            }
            
            if (pipeData.ConnectionType == PipeType.Angle) {
                
                return;
            }
            
            if (pipeData.ConnectionType == PipeType.Triple) {
                
                return;
            }
            
            
        }

        private void CheckWin() {
            Debug.Log("Plumber game WIN!!!");
            OnPlumberWin?.Invoke();
        }
    }
}