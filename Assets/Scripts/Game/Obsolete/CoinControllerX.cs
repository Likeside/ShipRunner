using System;
using System.Collections.Generic;
using UnityEngine;

namespace Game {
    public enum CoinType {
        Gold, Silver, Bronze
    }
    public class CoinControllerX {
        
        /*
        
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
                coin.OnCoinSectionDisabled += ReturnCoinToPool;
                section.OnSectionDisabled += coin.SectionDisabled; //отписаться!!
            }
        }

        void ReturnCoinToPool(Coin coin) {
            coin.Unsubscribe();
            _pooler.ReturnToPool(coin.gameObject);
        }
        */
    }
}