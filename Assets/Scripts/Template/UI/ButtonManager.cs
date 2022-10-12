using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using Utilities;
using Utilities.OdinEditor;

namespace Template.UI {
    public class ButtonManager: MonoBehaviour {

        [SerializeField] UiElementsActivenessSO _elementsActiveness;
        
        [SerializeField] Button _startBtn;
        [SerializeField] Button _quitButton;
        [SerializeField] Button _settingsButton;
        [SerializeField] Button _infoButton;
        [SerializeField] Button _backButton;
        [SerializeField] Button _tipButton;
        [SerializeField] Button _skipLevelButton;

        public event Action OnTipButtonPressed;
        public bool TipButtonActive => _elementsActiveness.tipButtonActive;


        void Start() {
            
            SetButton(_settingsButton, _elementsActiveness.settingsPanelActive, PanelManager.Instance.ToggleSettingsPanel);
            SetButton(_infoButton, _elementsActiveness.infoPanelActive, PanelManager.Instance.ToggleInfoPanel);
            SetButton(_backButton, _elementsActiveness.backButtonActive, SceneLoader.Instance.LoadMainMenu);
            SetButton(_tipButton, _elementsActiveness.tipButtonActive, TipButtonPressed);
            SetButton(_skipLevelButton, _elementsActiveness.skipLevelButtonActive, SceneLoader.Instance.SkipLevel);
            SetButton(_startBtn, true, SceneLoader.Instance.LoadNextLevel);
            SetButton(_quitButton, true, SceneLoader.Instance.Quit);

            if (_infoButton != null) {
                _infoButton.enabled = _elementsActiveness.infoPanelActive;
            }

            if (_backButton != null) {
                _backButton.enabled = _elementsActiveness.backButtonActive;
            }

            if (_tipButton != null) {
                _tipButton.enabled = _elementsActiveness.tipButtonActive;
            }

            if (_skipLevelButton != null) {
                _skipLevelButton.enabled = _elementsActiveness.skipLevelButtonActive;
            }
        }


        void SetButton(Button button, bool active, UnityAction listener) {
            if (button != null) {
                button.enabled = active;
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