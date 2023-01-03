using System;
using UnityEngine;
using Zenject;

namespace Game {
    public class WorldRotation : MonoBehaviour {

        [SerializeField] Transform _world;
        [SerializeField] float _rotationCoefficient;
        
        float _rotation;


        IInputController _inputController;
        
        [Inject]
        public void Construct(IInputController inputController, IGameplayConfig gameplayConfig) {
            _inputController = inputController;
            _rotationCoefficient = gameplayConfig.WorldRotationSpeed;
        }
        void Update() {
            
           // _rotation = -SteeringWheel.steeringInput * _rotationCoefficient;
            _rotation = - _inputController.SteeringInput * _rotationCoefficient;
            _world.Rotate(Vector3.up, _rotation);
        }
    }
}