using DragPuzzle.Services;
using Zenject;

namespace DragPuzzle.DI {
    public class DragPuzzleMonoInstaller : MonoInstaller {
        public override void InstallBindings() {
            Container
                .BindInterfacesAndSelfTo<DragPuzzleService>()
                .AsSingle();
        }
    }
}