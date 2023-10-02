using PlumberPuzzle.Config;
using PlumberPuzzle.Services;
using UnityEngine;
using Zenject;

namespace PlumberPuzzle.DI {
    [CreateAssetMenu(fileName = "PlumberInstaller",
        menuName = "Installers/Plumber/PlumberInstaller")]
    public class PlumberInstaller : ScriptableObjectInstaller<PlumberInstaller> {
        public PlumberConfig PlumberConfig;
        
        public override void InstallBindings() {
            Container
                .BindInstance(PlumberConfig)
                .AsSingle();

            Container
                .BindInterfacesAndSelfTo<PlumberService>()
                .AsSingle();
        }
    }
}