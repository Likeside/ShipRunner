using System;
using UnityEngine;

namespace Game {
    
    public class Coin: MonoBehaviour, ICollectable, IPoolType<CoinType> {
        [SerializeField] CoinType _coinType;

        public CoinType Type => _coinType;
        public event Action<Coin> OnCoinCollected;
        public void Collect() {
            OnCoinCollected?.Invoke(this);
            OnCoinCollected = null;
        }

    }
}