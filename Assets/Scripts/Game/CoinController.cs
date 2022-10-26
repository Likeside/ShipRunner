using System.Collections.Generic;
using GameScripts;
using UnityEngine;

namespace Game {
    public class CoinController {

        ObjectPooler _goldCoinPooler;
        ObjectPooler _silverCoinPooler;
        ObjectPooler _bronzeCoinPooler;

        public CoinController() {
            _goldCoinPooler = new ObjectPooler();
            _silverCoinPooler = new ObjectPooler();
            _CoinPooler = new ObjectPooler();
        }


        public void SpawnCoins(List<Vector3> positions) {
            foreach (var position in positions) {
                
            }
        }
    }
}