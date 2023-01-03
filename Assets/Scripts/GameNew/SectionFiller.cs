using System.Collections.Generic;
using Game;
using UnityEngine;

namespace GameNew {
    public class SectionFiller {

        PoolerBase<CoinType> _coinPooler;
        Dictionary<Section, List<GameObject>> _coins;


        public SectionFiller(SectionsConfigSO sectionsConfigSo, List<Section> initSections) {
            _coinPooler = new PoolerBase<CoinType>(sectionsConfigSo.coinDatas, 30);
            _coins = new Dictionary<Section, List<GameObject>>();
            foreach (var section in initSections) {
                _coins.Add(section, new List<GameObject>());
            }
        }
        
        public void FillSection(Section section) {
            //отслеживать свавн монеток, возвращать в пул только те, которые не собраны
            foreach (var pos in section.CollectablePositions) {
               var coin = _coinPooler.SpawnFromPool(CoinType.Gold);
               coin.transform.SetParent(section.transform);
               coin.transform.localPosition = pos;
            }
        }

        public void EmptySection(Section section) {
            Debug.Log("Emptying section");
            foreach (var coin in _coins[section]) {
                _coinPooler.ReturnToPool(coin);
            }

            _coins.Remove(section);
        }
    }
}