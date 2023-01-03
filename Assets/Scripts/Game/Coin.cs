using System;
using UnityEngine;
using Zenject;

namespace Game {
    
    public class Coin: MonoBehaviour, ICollectable, IPoolType<CoinType> {
        [SerializeField] CoinType _coinType;

        public CoinType Type => _coinType;
        public event Action<Coin> OnCoinCollected;
        public event Action<Coin> OnCoinSectionDisabled;

        float _rotationSpeed;

        public void SetRotationSpeed(float speed) {
            _rotationSpeed = speed;
        }
        public void Collect() {
            OnCoinCollected?.Invoke(this);
        }

        void Update() {
            transform.Rotate(Vector3.forward, _rotationSpeed, Space.Self);
        }

        public void SectionDisabled() {
            if (gameObject.activeSelf) {
                OnCoinSectionDisabled?.Invoke(this);
                Unsubscribe();
            }
        }
        
        public void Unsubscribe() {
            OnCoinCollected = null;
            OnCoinSectionDisabled = null;
        }

    }
}