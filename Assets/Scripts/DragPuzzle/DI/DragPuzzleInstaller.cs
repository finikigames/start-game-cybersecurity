using DragPuzzle.Configs;
using UnityEngine;
using Zenject;

namespace DragPuzzle.DI {
    [CreateAssetMenu(fileName = "DragPuzzleInstaller",
        menuName = "Installers/DragPuzzle/DragPuzzleInstaller")]
    public class DragPuzzleInstaller : ScriptableObjectInstaller<DragPuzzleInstaller> {
        public DragPuzzleGameConfig PuzzleGameConfig;
        
        public override void InstallBindings() {
            Container
                .BindInstance(PuzzleGameConfig)
                .AsSingle();
        }
    }
}