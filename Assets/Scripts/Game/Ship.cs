using System;
using UnityEngine;
using Zenject;

namespace Game {
    public class Ship: MonoBehaviour {
        [SerializeField] float _rotationMultiplier;


        public event Action OnCollidedWithObstacle;
        
        Vector3 _rotation = Vector3.zero;
        IInputController _inputController;
        
        
        [Inject]
        public void Construct(IInputController inputController, IGameplayConfig gameplayConfig) {
            _inputController = inputController;
            _rotationMultiplier = gameplayConfig.ShipRotationMultiplier;
        }
        void Update() {
            /*
            _rotation.y = -SteeringWheel.steeringInput*_rotationMultiplier;
            _rotation.z = SteeringWheel.steeringInput*_rotationMultiplier;
            */
            _rotation.y = -_inputController.SteeringInput * _rotationMultiplier;
            _rotation.z = _inputController.SteeringInput * _rotationMultiplier;
            transform.rotation = Quaternion.Euler(_rotation);
        }


        void OnTriggerEnter(Collider other) {
            if (other.transform.TryGetComponent(out ICollectable collectable) ) {
                collectable.Collect();
            }

            if (other.transform.TryGetComponent(out Obstacle obstacle)) {
                OnCollidedWithObstacle?.Invoke();
            }
        }
    }
}