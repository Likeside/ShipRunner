using Game;
using UnityEngine;
using Zenject;

namespace GameNew {
    public class GameInstaller: MonoInstaller {

        [SerializeField] InputController _inputController;
        [SerializeField] GameplayConfig _gameplayConfig;
        public override void InstallBindings() {
            Container.Bind<IInputController>().To<InputController>().FromInstance(_inputController);
            Container.Bind<IGameplayConfig>().To<GameplayConfig>().FromInstance(_gameplayConfig);
        }
    }
}