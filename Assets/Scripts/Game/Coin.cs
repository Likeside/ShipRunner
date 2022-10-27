using System;
using UnityEngine;

namespace Game {
    
    public class Coin: MonoBehaviour, ICollectable, IPoolType<CoinType> {
        [SerializeField] CoinType _coinType;

        public CoinType Type => _coinType;
        public event Action<Coin> OnCoinCollected;
        public event Action<Coin> OnCoinSectionDisabled;
        public void Collect() {
            OnCoinCollected?.Invoke(this);
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