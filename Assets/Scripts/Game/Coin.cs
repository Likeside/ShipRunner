using System;
using UnityEngine;

namespace Game {

    public enum CoinType {
        Gold, Silver, Bronze
    }
    public class Coin: MonoBehaviour, ICollectable {
        [SerializeField] CoinType _coinType;
        public event Action<GameObject, CoinType> OnCoinCollected;
        public void Collect() {
            OnCoinCollected?.Invoke(gameObject, _coinType);
        }
    }
}