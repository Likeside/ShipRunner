using System;
using UnityEngine;
using Zenject;

namespace Game {
    public class TailParticles: MonoBehaviour {
        [SerializeField] Transform _tail;
        [SerializeField] Transform _left;
        [SerializeField] Transform _right;
        [SerializeField] float _rotationMultiplier;


        float _backMultiplier;
        Vector3 _tailRotation = new Vector3(0, 180, 0);
        Vector3 _leftRotation = new Vector3(0, 190, 0);
        Vector3 _rightRotation = new Vector3(0, 170, 0);

        IInputController _inputController;

        [Inject]
        public void Construct(IInputController inputController, IGameplayConfig gameplayConfig) {
            _inputController = inputController;
            _rotationMultiplier = gameplayConfig.TailParticlesRotationMultiplier;
            _backMultiplier = _rotationMultiplier / 2f;
        }
        
        void Start() {
         //   _backMultiplier = _rotationMultiplier / 2f;
        }

        void Update() {
            
            /*
            _tailRotation.y = 180 - SteeringWheel.steeringInput*_rotationMultiplier;
            _leftRotation.y = 190 - SteeringWheel.steeringInput*_backMultiplier;
            _rightRotation.y = 170 - SteeringWheel.steeringInput*_backMultiplier;
            */
            
            _tailRotation.y = 180 - _inputController.SteeringInput*_rotationMultiplier;
            _leftRotation.y = 190 - _inputController.SteeringInput*_backMultiplier;
            _rightRotation.y = 170 - _inputController.SteeringInput*_backMultiplier;
            
            _tail.localRotation = Quaternion.Euler(_tailRotation);
            _left.localRotation = Quaternion.Euler(_leftRotation);
            _right.localRotation = Quaternion.Euler(_rightRotation);
        }
    }
}