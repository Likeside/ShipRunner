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

        float _timer;
        bool _fireReady;

        void Start() {
            _timer = _fireRate;
            _fireLeft.onClick.AddListener(FireLeft);
            _fireRight.onClick.AddListener(FireRight);
        }
        void Update() {
            _fireReady = _timer <= 0;
            _timer -= Time.deltaTime;
        }
        void FireRight() {
            if (_fireReady) {
                OnFiringRight?.Invoke();
                _timer = _fireRate;
            }
        }

        void FireLeft() {
            if (_fireReady) {
                OnFiringLeft?.Invoke();
                _timer = _fireRate;
            }
        }

        
        
    }
}