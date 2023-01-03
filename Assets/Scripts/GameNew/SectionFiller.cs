using System.Collections.Generic;
using Game;
using UnityEngine;

namespace GameNew {
    public class SectionFiller {

        PoolerBase<CoinType> _coinPooler;
        Dictionary<Section, List<GameObject>> _coins;

        float _coinRotationSpeed;
        
        public SectionFiller(SectionsConfigSO sectionsConfigSo, List<Section> initSections, float coinRotationSpeed) {
            _coinRotationSpeed = coinRotationSpeed;
            _coinPooler = new PoolerBase<CoinType>(sectionsConfigSo.coinDatas, 30);
            _coins = new Dictionary<Section, List<GameObject>>();
            foreach (var section in initSections) {
                _coins.Add(section, new List<GameObject>());
            }
        }
        
        public void FillSection(Section section) {
            FillWithCoins(section);
            FillWithInteraction(section);
        }

        public void ClearSection(Section section) {
            ClearCoins(section);
            ClearInteraction(section);
        }

        void FillWithCoins(Section section) {
            foreach (var pos in section.CollectablePositions) {
                var coin = _coinPooler.SpawnFromPoolComp<Coin>(CoinType.Gold);
                coin.SetRotationSpeed(_coinRotationSpeed);
                coin.transform.SetParent(section.transform);
                coin.transform.localPosition = pos;
                section.Coins.Add(coin.gameObject);
            }
        }

        void ClearCoins(Section section) {
            Debug.Log("Emptying section");
            foreach (var coin in section.Coins) {
                _coinPooler.ReturnToPool(coin);
            }
            section.Coins.Clear();
            _coins.Remove(section);
        }

        void FillWithInteraction(Section section) {
            
        }

        void ClearInteraction(Section section) {
            
        }
    }
}