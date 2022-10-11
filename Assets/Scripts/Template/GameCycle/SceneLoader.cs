using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Utilities {
    public class SceneLoader: GlobalSingleton<SceneLoader> {

        /*
        [SerializeField] Image _blackScreen;

        void Start() {
            Debug.Log("Starting scene loader");
            _blackScreen.material.color = Color.clear;
        }

        public void LoadLevel(int level) {

            LevelTracker.AdCounter++;
            if (level > LevelTracker.MaxLevels) {
                PanelManager.Instance.ToggleGameCompletePanel();
            }
            else {
                LevelTracker.LevelToLoad = level;
                AdsAndAnalyticsManager.Instance.LogLevelStart(LevelTracker.LevelToLoad);
                if (LevelTracker.AdCounter % AdsAndAnalyticsManager.Instance.InterstitialFrequency == 0 && LevelTracker.AdCounter > 0 && LevelTracker.LevelToLoad > 2) {
                    AdsAndAnalyticsManager.Instance.PlayInterstitial((() => LoadScene("Game")));   
                }
                else {
                    LoadScene("Game");
                }
            }
        }


        public void LoadNextLevel()
        {
            LevelTracker.AdCounter++;
            LevelTracker.LevelToLoad = SaveSystem.SaveSystem.LoadGame().currentLevelNumber;
            if (LevelTracker.LevelToLoad > LevelTracker.MaxLevels) {
                //PanelManager.Instance.ToggleGameCompletePanel();
                LevelTracker.LevelToLoad = 1;
                AdsAndAnalyticsManager.Instance.LogLevelStart(LevelTracker.LevelToLoad);
                LoadScene("Game");
            }
            else {
                AdsAndAnalyticsManager.Instance.LogLevelStart(LevelTracker.LevelToLoad);
                if (LevelTracker.AdCounter % AdsAndAnalyticsManager.Instance.InterstitialFrequency == 0 && LevelTracker.AdCounter > 0 && LevelTracker.LevelToLoad > 2) {
                 AdsAndAnalyticsManager.Instance.PlayInterstitial((() => LoadScene("Game")));   
                }
                else {
                    LoadScene("Game");
                }
            }
        }

        public void LoadMainMenu() {
            Debug.Log("LoadingMenu");
            AdsAndAnalyticsManager.Instance.ToggleBanner(false);
            LoadScene("Menu");
        }
        
        
        public void BsFadeIn() {
            _blackScreen.material.DOColor(Color.clear, GameConfig.Instance.config.blackScreenFadeDelay).SetUpdate(true);
            Time.timeScale = 1f;
        }

        public void BsFadeOut() {
          _blackScreen.material.DOColor(GameConfig.Instance.config.transitionColor, GameConfig.Instance.config.blackScreenFadeDelay).SetUpdate(true);
        }


        public void Quit() {
            Application.Quit();
        }


        void LoadScene(string sceneName) {
            var tween = _blackScreen.material.DOColor(GameConfig.Instance.config.transitionColor,
                GameConfig.Instance.config.blackScreenFadeDelay).SetUpdate(true);
            tween.onComplete = () => SceneManager.LoadScene(sceneName);
            
        }
       */ 
    }
    
}