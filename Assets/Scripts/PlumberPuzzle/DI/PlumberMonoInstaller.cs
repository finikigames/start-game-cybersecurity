using PlumberPuzzle.UI;
using Zenject;

namespace PlumberPuzzle.DI {
    public class PlumberMonoInstaller : MonoInstaller {
        public PlumberField Field;

        public override void InstallBindings() {
            Container
                .BindInstance(Field)
                .AsSingle();
        }
    }
}