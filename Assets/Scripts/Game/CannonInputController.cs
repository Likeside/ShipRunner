using System;
using UnityEngine;
using UnityEngine.UI;

namespace Game {
    public class CannonInputController: MonoBehaviour {
        [SerializeField] Button _fireLeft;
        [SerializeField] Button _fireRight;
        [SerializeField] float _fireRate;

        public event Action OnFiringLeft;
        public event Action OnFiringRight;

        float _timerLeft;
        float _timerRight;
        bool _fireReadyLeft;
        bool _fireReadyRight;

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