using DragPuzzle.Services;
using DragPuzzle.UI;
using Zenject;

namespace DragPuzzle.DI {
    public class DragPuzzleMonoInstaller : MonoInstaller {
        public DragPuzzleField Field;
        
        public override void InstallBindings() {
            Container
                .BindInterfacesAndSelfTo<DragPuzzleService>()
                .AsSingle();

            Container
                .BindInstance(Field)
                .AsSingle();
        }
    }
}