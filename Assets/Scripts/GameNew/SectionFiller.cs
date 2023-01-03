using System.Collections.Generic;
using Game;
using UnityEngine;

namespace GameNew {
    public class SectionFiller {

        PoolerBase<CoinType> _coinPooler;
        Dictionary<Section, List<GameObject>> _coins;

        public void FillSection(Section section) {
            foreach (var pos in section.CollectablePositions) {
               var coin = _coinPooler.SpawnFromPool(CoinType.Gold);
               coin.transform.SetParent(section.transform);
               coin.transform.localPosition = pos;
            }
        }

        public void EmptySection(Section section) {
            foreach (var coin in _coins[section]) {
                _coinPooler.ReturnToPool(coin);
            }

            _coins.Remove(section);
        }
    }
}