using Game;
using Template.UI;
using UnityEngine;
using Utilities;

public class GameController : LocalSingleton<GameController> {
        
        [SerializeField] ButtonManager _buttonManager;


        [SerializeField] SectionsConfigSO _sectionsConfigSo;
        [SerializeField] SectionMover _sectionMover;


        CoinController _coinController;

        void Start() { 
                if (_buttonManager.TipButtonActive) _buttonManager.OnTipButtonPressed += TipButtonPressed;
                if (_buttonManager.PauseButtonActive) _buttonManager.OnTipButtonPressed += PauseButtonPressed;
                if (PanelManager.Instance.ElementsActiveness.rateUsPanelActive) AdsAndAnalyticsManager.Instance.OnRateUsLinkOpened += RateUsLinkOpened;
                
                GameStart();
        }

        void RateUsLinkOpened() {
                Debug.Log("Rate us link opened");
        }

        void PauseButtonPressed() {
                Debug.Log("Pause button pressed");
        }

        void TipButtonPressed() {
                Debug.Log("Tip button pressed");
        }



        void GameStart() {
                _coinController = new CoinController(_sectionsConfigSo);
                _sectionMover.Initialize(_sectionsConfigSo);
                _sectionMover.OnNewSectionSpawned += SpawnCoins;
        }


        void SpawnCoins(Section section) {
                _coinController.SpawnCoins(section, CoinType.Gold, AddScore); //TODO: задать вероятность спавна коинов разного типа 
        }

        void AddScore(Coin coin) {
                Debug.Log("Coin collected, type: " + coin.Type);
        }
        
}
