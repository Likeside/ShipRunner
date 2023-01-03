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
        
        void Update() {
            transform.Rotate(Vector3.forward, _rotationSpeed, Space.Self);
        }
        public void SetRotationSpeed(float speed) {
            _rotationSpeed = speed;
        }
        public void Collect() {
            OnCoinCollected?.Invoke(this);
        }
    }
}