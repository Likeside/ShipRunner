using System;
using GameNew.Enums;
using UnityEngine;
using Zenject;

namespace Game {
    
    public class Coin: MonoBehaviour, ICollectable, IPoolType<CoinType>, IExecutable {
        [SerializeField] CoinType _coinType;

        public CoinType Type => _coinType;
        public event Action<Coin> OnCoinCollected;
        float _rotationSpeed;
        
        public void Execute() {
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