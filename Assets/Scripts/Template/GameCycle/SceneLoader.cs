using DG.Tweening;
using Template.GameCycle;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Utilities.OdinEditor;

namespace Utilities {
    public class SceneLoader: GlobalSingleton<SceneLoader> {

        
        [SerializeField] Image _blackScreen;
        [SerializeField] AdsAndAnalyticsConfigSO _adsConfig;

        public ISaveSystem SaveSystem { get; private set; }

        protected override void OnSingletonAwake() {
            base.OnSingletonAwake();
            switch (PanelManager.Instance.ElementsActiveness.saveSystemType) {
                case SaveSystemType.Binary:
                    SaveSystem = new SaveSystemBinary();
                    break;
                case SaveSystemType.Json:
                    SaveSystem = new SaveSystemJson();
                    break;
                default:
                    SaveSystem = new SaveSystemJson();
                    break;
            }
        }

        void Start() {
            Debug.Log("Starting scene loader");
            _blackScreen.material.color = Color.clear;
            LevelTracker.LevelToLoad = SaveSystem.LoadGame().LevelToLoad;
        }

        public void LoadLevel(int level) {

            LevelTracker.AdCounter++;
            if (level > LevelTracker.MaxLevels) {
                PanelManager.Instance.ToggleGameCompletePanel();
            }
            else {
                LevelTracker.LevelToLoad = level;
                AdsAndAnalyticsManager.Instance.LogLevelStart(LevelTracker.LevelToLoad);
                if (LevelTracker.AdCounter % AdsAndAnalyticsManager.Instance.InterstitialFrequency == 0 && 
                    LevelTracker.AdCounter > 0 && LevelTracker.LevelToLoad > _adsConfig.interstitialFirstLevel) {
                    AdsAndAnalyticsManager.Instance.PlayInterstitial((() => LoadScene("Game")));   
                }
                else {
                    LoadScene("Game");
                }
            }
        }
        
        public void LoadNextLevel()
        {
            Debug.Log("Trying to load next level");
            LevelTracker.AdCounter++;
          //  LevelTracker.LevelToLoad = SaveSystem.SaveSystem.LoadGame().currentLevelNumber;
            if (LevelTracker.LevelToLoad > LevelTracker.MaxLevels) {
                //PanelManager.Instance.ToggleGameCompletePanel();
                Debug.Log("1");
                LevelTracker.LevelToLoad = 1;
                AdsAndAnalyticsManager.Instance.LogLevelStart(LevelTracker.LevelToLoad);
                LoadScene("Game");
            }
            else {
                Debug.Log("2");
                AdsAndAnalyticsManager.Instance.LogLevelStart(LevelTracker.LevelToLoad);
                if (LevelTracker.AdCounter % AdsAndAnalyticsManager.Instance.InterstitialFrequency == 0 && LevelTracker.AdCounter > 0
                    && LevelTracker.LevelToLoad > _adsConfig.interstitialFirstLevel) {
                    Debug.Log("3");
                    AdsAndAnalyticsManager.Instance.PlayInterstitial((() => LoadScene("Game")));   
                }
                else {
                    Debug.Log("4");
                    LoadScene("Game");
                }
            }
        }

        public void SkipLevel() {
            //TODO: IMPLEMENT SKIP FUNCTIONALITY
        }

        public void LoadMainMenu() {
            Debug.Log("LoadingMenu");
            AdsAndAnalyticsManager.Instance.ToggleBanner(false);
            LoadScene("Menu");
        }
        
        
        public void BsFadeIn() {
            _blackScreen.material.DOColor(Color.clear, PanelManager.Instance.ElementsActiveness.blackScreenFadeDelay).SetUpdate(true);
            Time.timeScale = 1f;
        }

        public void BsFadeOut() {
          _blackScreen.material.DOColor(PanelManager.Instance.ElementsActiveness.transitionColor, PanelManager.Instance.ElementsActiveness.blackScreenFadeDelay).SetUpdate(true);
        }


        public void Quit() {
            Application.Quit();
        }


        void LoadScene(string sceneName) {
            
            var tween = _blackScreen.material.DOColor(PanelManager.Instance.ElementsActiveness.transitionColor,
                PanelManager.Instance.ElementsActiveness.blackScreenFadeDelay).SetUpdate(true);
            tween.onComplete = () => SceneManager.LoadScene(sceneName);

        }
    }
    
}