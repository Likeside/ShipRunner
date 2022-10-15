using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using Utilities;
using Utilities.OdinEditor;

namespace Template.UI {
    public class ButtonManager: MonoBehaviour {
        
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
        [SerializeField] Button _enButton;
        [SerializeField] Button _ruButton;
        [SerializeField] Button _musicButton;
        [SerializeField] Button _soundButton;
        [SerializeField] Button[] _rewardedFailedPanelCloseButtons;
        public event Action OnTipButtonPressed;
        public event Action OnPauseButtonPressed;
        public bool TipButtonActive => PanelManager.Instance.ElementsActiveness.tipButtonActive;
        public bool PauseButtonActive => PanelManager.Instance.ElementsActiveness.pauseButtonActive;
        void Start() {
            Debug.Log("Button manager start");
            SetButton(_settingsButton, PanelManager.Instance.ElementsActiveness.settingsPanelActive, PanelManager.Instance.ToggleSettingsPanel);
            SetButton(_infoButton, PanelManager.Instance.ElementsActiveness.infoPanelActive, PanelManager.Instance.ToggleInfoPanel);
            SetButton(_backButton, PanelManager.Instance.ElementsActiveness.backButtonActive, SceneLoader.Instance.LoadMainMenu);
            SetButton(_tipButton, PanelManager.Instance.ElementsActiveness.tipButtonActive, (() => OnTipButtonPressed?.Invoke()));
            SetButton(_skipLevelButton, PanelManager.Instance.ElementsActiveness.skipLevelButtonActive, SceneLoader.Instance.SkipLevel);
            SetButton(_startBtn, true, SceneLoader.Instance.LoadNextLevel);
            SetButton(_quitButton, PanelManager.Instance.ElementsActiveness.quitButtonActive, SceneLoader.Instance.Quit);
            SetButton(_pauseButton, PanelManager.Instance.ElementsActiveness.pauseButtonActive, (() => OnPauseButtonPressed?.Invoke()) );
            SetButton(_infoPanelCloseButton, PanelManager.Instance.ElementsActiveness.infoPanelActive, PanelManager.Instance.ToggleInfoPanel);
            SetButton(_settingsPanelCloseButton, PanelManager.Instance.ElementsActiveness.settingsPanelActive, PanelManager.Instance.ToggleSettingsPanel);
            SetButton(_enButton, PanelManager.Instance.ElementsActiveness.enButtonActive, (() => TextLoader.Instance.SwitchLocalization(Localization.EN)));
            SetButton(_ruButton, PanelManager.Instance.ElementsActiveness.ruButtonActive, (() => TextLoader.Instance.SwitchLocalization(Localization.RU)));
            SetButton(_musicButton, PanelManager.Instance.ElementsActiveness.musicButtonActive, AudioManager.Instance.ToggleMusicButton);
            SetButton(_soundButton, PanelManager.Instance.ElementsActiveness.soundButtonActive, AudioManager.Instance.ToggleSoundButton);

            foreach (var button in _rewardedFailedPanelCloseButtons) {
                SetButton(button, PanelManager.Instance.ElementsActiveness.rewardedFailedPanelActive, PanelManager.Instance.ToggleRewardedFailedPanel);
            }
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