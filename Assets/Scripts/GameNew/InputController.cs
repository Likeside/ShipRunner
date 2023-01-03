using System;
using Game;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace GameNew {
    public class InputController: MonoBehaviour, IInputController {
        
        [SerializeField] Button _fireLeft;
        [SerializeField] Button _fireRight;
        [SerializeField] SteeringWheel _steeringWheel;
         
        public event Action OnFiringLeft;
        public event Action OnFiringRight;
        public float SteeringInput => _steeringWheel.SteeringInput;
        
        
        float _timerLeft;
        float _timerRight;
        float _fireRate;
        bool _fireReadyLeft;
        bool _fireReadyRight;


        [Inject]
        public void Construct(IGameplayConfig gameplayConfig) {
            _fireRate = gameplayConfig.FireRate;
        }
        void Start() {
            _timerLeft = 0;
            _timerRight = 0;
            _fireLeft.onClick.AddListener(FireLeft);
            _fireRight.onClick.AddListener(FireRight);
        }
        void Update() {
            _fireReadyLeft = _timerLeft <= 0;
            _fireReadyRight = _timerRight <= 0;
            _timerLeft -= Time.deltaTime;
            _timerRight -= Time.deltaTime;
        }
        void FireRight() {
            if (_fireReadyRight) {
                OnFiringRight?.Invoke();
                _timerRight = _fireRate;
            }
        }

        void FireLeft() {
            if (_fireReadyLeft) {
                OnFiringLeft?.Invoke();
                _timerLeft = _fireRate;
            }
        }
    }
}