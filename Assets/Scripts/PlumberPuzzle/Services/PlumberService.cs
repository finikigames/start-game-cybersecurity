using System;
using System.Collections.Generic;
using PlumberPuzzle.Config;
using PlumberPuzzle.Data;
using PlumberPuzzle.UI;
using UnityEngine;
using Zenject;

namespace PlumberPuzzle.Services {
    public class PlumberService : IInitializable {
        private readonly PlumberConfig _plumberConfig;
        private readonly PlumberField _field;

        private List<int> _connects = new();
        private List<int> _neighbors = new();

        private List<int> _defaultNeighbors = new() { 10, -10, 1, -1};
        
        public Action OnPlumberWin { get; set; }

        public PlumberService(PlumberConfig plumberConfig,
                              PlumberField field) {
            _plumberConfig = plumberConfig;
            _field = field;
        }
        
        public void Initialize() {
            _plumberConfig.Initialize();

            var allPipes = new PipeView[_plumberConfig._PipeTypes.Length];
            
            var column = 0;
            var row = 0;
            for (var index = 0; index < _plumberConfig._PipeTypes.Length; index++) {
                if ((column % 10) == _plumberConfig.Columns) {
                    row++;
                    column = 0;
                }

                var pipeType = _plumberConfig._PipeTypes[index];

                if (pipeType == PipeType.None) {
                    _field.InitializeNull(index);
                    column++;
                    allPipes[index] = null;
                    continue;
                }
                
                var pipeIcon = _plumberConfig.GetPipeView(pipeType);
                var cellIndex = row * 10 + column;
                column++;
                
                _field.InitializePipe(pipeIcon, RotatePipe, cellIndex, pipeType, index);
                allPipes[index] = _field.GetPipeData(cellIndex);
            }

            foreach (var pipe in allPipes) {
                if (pipe == null) continue;
                CalculateConnection(pipe.Data, pipe.Index);
            }
        }

        private void RotatePipe(int index) {
            var pipe = _field.GetPipeData(index);
            
            pipe.RotatePipe();
            var pipeData = pipe.Data;

            CalculateConnection(pipeData, index);
            RecalculateNeighbors(index);
            
            CheckWin();
        }

        private void CalculateConnection(PipeData pipeData, int index) {
            _neighbors.Clear();
            _connects.Clear();

            FillConnects(pipeData);
            GetConnection(pipeData, index);
        }

        private void FillConnects(PipeData pipeData) {
            if (pipeData.ConnectionType == PipeType.Line) {
                if (pipeData.Rotation == PipeRotationType.ZeroR ||
                    pipeData.Rotation == PipeRotationType.TwoR) {
                    _connects.Add(-1);
                    _connects.Add(1);
                    return;
                }
                
                _connects.Add(-10);
                _connects.Add(10);
                return;
            }
            
            if (pipeData.ConnectionType == PipeType.Angle) {
                switch (pipeData.Rotation) {
                    case PipeRotationType.ZeroR:
                        _connects.Add(10);
                        _connects.Add(1);
                        break;
                    case PipeRotationType.OneR:
                        _connects.Add(1);
                        _connects.Add(-10);
                        break;
                    case PipeRotationType.TwoR:
                        _connects.Add(-10);
                        _connects.Add(-1);
                        break;
                    default:
                        _connects.Add(-1);
                        _connects.Add(10);
                        break;
                }
                return;
            }
            
            if (pipeData.ConnectionType == PipeType.Triple) {
                switch (pipeData.Rotation) {
                    case PipeRotationType.ZeroR:
                        _connects.Add(-1);
                        _connects.Add(10);
                        _connects.Add(1);
                        break;
                    case PipeRotationType.OneR:
                        _connects.Add(10);
                        _connects.Add(1);
                        _connects.Add(-10);
                        break;
                    case PipeRotationType.TwoR:
                        _connects.Add(1);
                        _connects.Add(-10);
                        _connects.Add(-1);
                        break;
                    default:
                        _connects.Add(-10);
                        _connects.Add(-1);
                        _connects.Add(10);
                        break;
                }
                return;
            }

            _connects.Add(-1);
            _connects.Add(10);
            _connects.Add(1);
            _connects.Add(-10);
        }

        private void GetConnection(PipeData pipeData, int index) {
            pipeData.ConnectedCells.Clear();
            
            foreach (var connect in _connects) {
                var neighbor = index + ((connect / 10) * 10) + (connect % 10);
                var neighborView = _field.GetPipeData(neighbor);
                if (neighborView == null) continue;

                var neighborData = neighborView.Data;
                
                if (!CanConnect(neighborData, connect)) continue;
                
                pipeData.ConnectedCells.Add(neighbor);
            }
        }

        private bool CanConnect(PipeData neighbor, int connect) {
            if (neighbor.ConnectionType == PipeType.Intersection) {
                return true;
            }

            if (connect == -10) {
                if (neighbor.ConnectionType == PipeType.Line) {
                    return neighbor.Rotation == PipeRotationType.OneR ||
                           neighbor.Rotation == PipeRotationType.ThreeR;
                }

                if (neighbor.ConnectionType == PipeType.Angle) {
                    return neighbor.Rotation == PipeRotationType.ZeroR ||
                           neighbor.Rotation == PipeRotationType.ThreeR;
                }

                return neighbor.Rotation != PipeRotationType.TwoR;
            }

            if (connect == 10) {
                if (neighbor.ConnectionType == PipeType.Line) {
                    return neighbor.Rotation == PipeRotationType.OneR ||
                           neighbor.Rotation == PipeRotationType.ThreeR;
                }

                if (neighbor.ConnectionType == PipeType.Angle) {
                    return neighbor.Rotation == PipeRotationType.OneR ||
                           neighbor.Rotation == PipeRotationType.TwoR;
                }

                return neighbor.Rotation != PipeRotationType.ZeroR;
            }

            if (connect == 1) {
                if (neighbor.ConnectionType == PipeType.Line) {
                    return neighbor.Rotation == PipeRotationType.ZeroR ||
                           neighbor.Rotation == PipeRotationType.TwoR;
                }

                if (neighbor.ConnectionType == PipeType.Angle) {
                    return neighbor.Rotation == PipeRotationType.TwoR ||
                           neighbor.Rotation == PipeRotationType.ThreeR;
                }

                return neighbor.Rotation != PipeRotationType.OneR;
            }
            
            if (neighbor.ConnectionType == PipeType.Line) {
                return neighbor.Rotation == PipeRotationType.ZeroR ||
                       neighbor.Rotation == PipeRotationType.TwoR;
            }

            if (neighbor.ConnectionType == PipeType.Angle) {
                return neighbor.Rotation == PipeRotationType.ZeroR ||
                       neighbor.Rotation == PipeRotationType.OneR;
            }

            return neighbor.Rotation != PipeRotationType.ThreeR;
        }

        private void RecalculateNeighbors(int pipeIndex) {
            foreach (var connect in _defaultNeighbors) {
                var neighbor = pipeIndex + ((connect / 10) * 10) + (connect % 10);
                var pipe = _field.GetPipeData(neighbor);
                if (pipe == null) continue;
                
                var neighborData = pipe.Data;

                CalculateConnection(neighborData, neighbor);
            }
        }

        private void CheckWin() {
            for (var index = 0; index < _plumberConfig.WinConnections.Length; index++) {
                if (index == _plumberConfig.WinConnections.Length - 1) continue;
                
                var connection = _plumberConfig.WinConnections[index];
                var data = _field.GetPipeData(connection).Data;

                if (!data.ConnectedCells.Contains(_plumberConfig.WinConnections[index + 1])) return;
            }

            Debug.Log("Plumber game WIN!!!");
            OnPlumberWin?.Invoke();
        }
    }
}