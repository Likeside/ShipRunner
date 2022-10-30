using Game;
using Template.UI;
using UnityEngine;
using Utilities;

public class GameController : LocalSingleton<GameController> {
        
        [SerializeField] ButtonManager _buttonManager;


        [SerializeField] SectionsConfigSO _sectionsConfigSo;
        [SerializeField] SectionMover _sectionMover;
        [SerializeField] CannonInputController _cannonInputController;
        [SerializeField] Ship _ship;


        CoinController _coinController;
        TowerController _towerController;

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
                _towerController = new TowerController(_sectionsConfigSo, _cannonInputController);
                //_towerController.OnTowerFired += Lost;
                _sectionMover.Initialize(_sectionsConfigSo);
                _sectionMover.OnNewSectionSpawned += SpawnCoins;
              //  _sectionMover.OnNewSectionSpawned += SpawnTowers;
                _ship.OnCollidedWithObstacle += Lost;
        }

        void SpawnTowers(Section section) {
                _towerController.SpawnTowers(section, AddScoreForTower);
        }


        void SpawnCoins(Section section) {
                _coinController.SpawnCoins(section, CoinType.Gold, AddScoreForCoin); //TODO: задать вероятность спавна коинов разного типа 
        }

        void AddScoreForCoin(Coin coin) {
                Debug.Log("Coin collected, type: " + coin.Type);
        }

        void AddScoreForTower(Tower tower) {
                Debug.Log("Tower destroyed");
        }
        
        void Lost() {
                Debug.Log("Game lost");
                PanelManager.Instance.ToggleGameCompletePanel();
        }


        void Unsubscribe() {
                _towerController.OnTowerFired -= Lost;
                _sectionMover.OnNewSectionSpawned -= SpawnCoins;
                _sectionMover.OnNewSectionSpawned -= SpawnTowers;
                _ship.OnCollidedWithObstacle -= Lost;  
        }
        
}
