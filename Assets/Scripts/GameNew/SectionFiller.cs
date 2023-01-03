using System.Collections.Generic;
using Game;
using UnityEngine;

namespace GameNew {
    public class SectionFiller {

        PoolerBase<CoinType> _coinPooler;
        Dictionary<Section, List<GameObject>> _coins;

        public void FillSection(Section section) {
            
        }

        public void EmptySection(Section section) {
            foreach (var coin in _coins[section]) {
                _coinPooler.ReturnToPool(coin);
            }

            _coins.Remove(section);
        }
    }
}