using System.Collections.Generic;
using DragPuzzle.Configs;
using UnityEngine;
using Zenject;

namespace DragPuzzle.Services {
    public class DragPuzzleService : IInitializable, ITickable {
        private readonly DragPuzzleGameConfig _gameConfig;

        private Dictionary<string, string> _puzzleMatch = new();

        public DragPuzzleService(DragPuzzleGameConfig gameConfig) {
            _gameConfig = gameConfig;
        } 
        
        public void Tick() {
        }

        public void Initialize() {
        }
        
        //logic check distance between piece and ghost piece
        private void Check() {
            Vector3 from = Vector3.zero;//rofls
            Vector3 to = Vector3.zero;//rofls
            var distance = Vector3.Distance(from, to);

            if (distance < _gameConfig.DropDistance) {
                //setLock
                //fit into ghost piece
            }
        }
    }
}