using Game;
using UnityEngine;

namespace GameNew {
    public class SectionFiller {

        
        PoolerBase<CoinType> _coinPooler;
         IInteractionController _interactionController;

        float _coinRotationSpeed;
        
        public SectionFiller(SectionsConfigSO sectionsConfigSo, IInteractionController interactionController, float coinRotationSpeed) {
            _interactionController = interactionController;
            _coinRotationSpeed = coinRotationSpeed;
            _coinPooler = new PoolerBase<CoinType>(sectionsConfigSo.coinDatas, 30);
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
                coin.OnCoinCollected += CoinCollected;
                section.Coins.Add(coin.gameObject);
            }
        }

        void CoinCollected(Coin coin) {
            _interactionController.CollectCoin(coin);
            coin.OnCoinCollected -= CoinCollected;
            _coinPooler.ReturnToPool(coin.gameObject);
        }

        void ClearCoins(Section section) {
            Debug.Log("Emptying section");
            foreach (var coin in section.Coins) {
                _coinPooler.ReturnToPool(coin);
            }
            section.Coins.Clear();
        }

        void FillWithInteraction(Section section) {
            
        }

        void ClearInteraction(Section section) {
            
        }
    }
}