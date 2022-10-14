using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using Utilities;
using Utilities.OdinEditor;

namespace Template.UI {
    public class ButtonManager: MonoBehaviour {

        [SerializeField] UiElementsConfigSO _elementsActiveness;
        
        [SerializeField] Button _startBtn;
        [SerializeField] Button _quitButton;
        [SerializeField] Button _settingsButton;
        [SerializeField] Button _infoButton;
        [SerializeField] Button _backButton;
        [SerializeField] Button _tipButton;
        [SerializeField] Button _skipLevelButton;
        [SerializeField] Button _pauseButton;
        [SerializeField] Button _infoPanelCloseButton;
        [SerializeField] Button _settingsPanelCloseButton;
        public event Action OnTipButtonPressed;
        public event Action OnPauseButtonPressed;
        public bool TipButtonActive => _elementsActiveness.tipButtonActive;
        public bool PauseButtonActive => _elementsActiveness.pauseButtonActive;
        void Start() {
            Debug.Log("Button manager start");
            SetButton(_settingsButton, _elementsActiveness.settingsPanelActive, PanelManager.Instance.ToggleSettingsPanel);
            SetButton(_infoButton, _elementsActiveness.infoPanelActive, PanelManager.Instance.ToggleInfoPanel);
            SetButton(_backButton, _elementsActiveness.backButtonActive, SceneLoader.Instance.LoadMainMenu);
            SetButton(_tipButton, _elementsActiveness.tipButtonActive, (() => OnTipButtonPressed?.Invoke()));
            SetButton(_skipLevelButton, _elementsActiveness.skipLevelButtonActive, SceneLoader.Instance.SkipLevel);
            SetButton(_startBtn, true, SceneLoader.Instance.LoadNextLevel);
            SetButton(_quitButton, _elementsActiveness.quitButtonActive, SceneLoader.Instance.Quit);
            SetButton(_pauseButton, _elementsActiveness.pauseButtonActive, (() => OnPauseButtonPressed?.Invoke()) );
            SetButton(_infoPanelCloseButton, _elementsActiveness.infoPanelActive, PanelManager.Instance.ToggleInfoPanel);
            SetButton(_settingsPanelCloseButton, _elementsActiveness.settingsPanelActive, PanelManager.Instance.ToggleSettingsPanel);
        }
        void SetButton(Button button, bool active, UnityAction listener) {
            if (button != null) {
                button.gameObject.SetActive(active);
                if (active) {
                    button.onClick.RemoveAllListeners();
                    button.onClick.AddListener(listener);
                }
            }
        }
        void TipButtonPressed() {
            OnTipButtonPressed?.Invoke();
        }
    }
}