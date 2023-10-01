using UnityEngine;
using Zenject;

namespace PuzzleFeature.DI {
    public class PuzzleInstaller : MonoInstaller {
        public Puzzle Puzzle;
        
        public override void InstallBindings() {
            Container
                .BindInterfacesAndSelfTo<Puzzle>()
                .FromInstance(Puzzle)
                .AsSingle();
        }
    }
}