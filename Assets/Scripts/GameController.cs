using Game;
using Template.AdsAndAnalytics;
using Template.UI;
using UnityEngine;
using Utilities;

public class GameController : LocalSingleton<GameController> {
        
        [SerializeField] ButtonManager _buttonManager;
        [SerializeField] Ship _ship;



        void Start() { 
                if (_buttonManager.TipButtonActive) _buttonManager.OnTipButtonPressed += TipButtonPressed;
                if (_buttonManager.PauseButtonActive) _buttonManager.OnTipButtonPressed += PauseButtonPressed;
                if (PanelManager.Instance.ElementsActiveness.rateUsPanelActive) ExternalLinksManager.Instance.OnRateUsLinkOpened += RateUsLinkOpened;
                
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
                _ship.OnCollidedWithObstacle += Lost;
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
                _ship.OnCollidedWithObstacle -= Lost;  
        }
        
}
