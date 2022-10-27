using System;
using System.Collections.Generic;
using UnityEngine;

namespace Game {
    public enum CoinType {
        Gold, Silver, Bronze
    }
    public class CoinController {

        
        PoolerBase<CoinType> _pooler;
        public CoinController(SectionsConfigSO sectionsConfigSo) {
            _pooler = new PoolerBase<CoinType>(sectionsConfigSo.coinDatas, 20);
        }


        public void SpawnCoins(Section section, CoinType type, Action<Coin> coinCollectedCallback) {
            foreach (var position in section.CollectablePositions) {
                var coin = _pooler.SpawnFromPoolComp<Coin>(type);
                var tr = coin.transform;
                tr.SetParent(section.transform);
                tr.localPosition = position;
                coin.OnCoinCollected += ReturnCoinToPool;
                coin.OnCoinCollected += coinCollectedCallback;
            }
        }

        void ReturnCoinToPool(Coin coin) {
            coin.OnCoinCollected -= ReturnCoinToPool;
            _pooler.ReturnToPool(coin.gameObject);
        }

        void CoinCollected(Coin coin) {
          //  coin.OnCoinCollected -= CoinCollected;
          //  Debug.Log("Coin collected, type: " + coin.Type);
        }
    }
}