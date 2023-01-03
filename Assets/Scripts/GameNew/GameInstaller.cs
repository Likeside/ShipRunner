using Game;
using Zenject;

namespace GameNew {
    public class GameInstaller: MonoInstaller {
        
        
        public override void InstallBindings() {
            Container.Bind<IInputController>().To<InputController>().AsSingle();
            Container.Bind<IGameplayConfig>().To<GameplayConfig>().AsSingle();
        }
    }
}