using System;
using UnityEngine;
using UnityEngine.UI;
using Utilities.OdinEditor;

namespace Utilities {
    public class PanelManager: LocalSingleton<PanelManager> {

        [SerializeField] UiElementsConfigSO _elementsActiveness;
        
        [SerializeField] PanelEffectsConfigSO _panelEffectsConfigSo;
        [Header("Panels")]
        [SerializeField] GameObject _pausePanel;
        [SerializeField] GameObject _gameCompletePanel;
        [SerializeField] GameObject _settingsPanel;
        [SerializeField] GameObject _infoPanel;
        [SerializeField] GameObject _policyPanel;
        [SerializeField] GameObject _agePanel;
        [SerializeField] GameObject _topPanel;
        
        [Header("TutorialPanel")]
        [SerializeField] GameObject _tutPanel;
        [SerializeField] Image _tutorialImage;
        [SerializeField] TextSetter _tutorialText;
        [SerializeField] TextSetterMesh _versionText;
        
        public PanelEffectsConfigSO PanelEffectsConfigSo => _panelEffectsConfigSo;
        public UiElementsConfigSO ElementsActiveness => _elementsActiveness;

        void Start() {
            SceneLoader.Instance.BsFadeIn();
            if (_policyPanel != null) {
                if (AppPolicyManager.Instance.AppPolicyAccepted) {
                    _policyPanel.SetActive(false);
                    if(AdsAndAnalyticsManager.Instance == null) Debug.Log("Instance null");
                    AdsAndAnalyticsManager.Instance.Initialize();
                }
                else {
                    _policyPanel.SetActive(true);
                }
            }
            if (_agePanel != null) {
                _agePanel.SetActive(!AppPolicyManager.Instance.UserHasProvidedAge());
            }

            if (_versionText != null) {
                _versionText.Append(LevelTracker.Version + " (C) 2022 - " + DateTime.Now.Year);
            }
            SetPanelsActiveness();
        }
        
        public void TogglePausePanel() {
          AdsAndAnalyticsManager.Instance.ToggleBanner(_pausePanel.GetComponent<PanelEffect>().Hidden);
          TogglePanel(_pausePanel);
        }
        
        public void ToggleGameCompletePanel() {
          AdsAndAnalyticsManager.Instance.ToggleBanner(_gameCompletePanel.GetComponent<PanelEffect>().Hidden);
          TogglePanel(_gameCompletePanel);
        }
        
        public void ToggleSettingsPanel() {
            TogglePanel(_settingsPanel);
            if(_elementsActiveness.infoPanelActive) TogglePanel(_infoPanel, false);
        }
        
        public void ToggleInfoPanel() {
            TogglePanel(_infoPanel);
           if(_elementsActiveness.settingsPanelActive) TogglePanel(_settingsPanel, false);
        }
        public void ToggleTutorialPanel() {
            TogglePanel(_tutPanel);
        }
        
        public void ToggleTutorialPanel(Sprite image, string tutTextKey) {
            _tutorialImage.sprite = image;
            _tutorialText.SetText(tutTextKey);
            ToggleTutorialPanel();
        }
        
        public void ClosePolicyPanel() {
            _policyPanel.SetActive(false);
            AppPolicyManager.Instance.AcceptAppPolicy();
            AdsAndAnalyticsManager.Instance.LogFirstGameEnter();
            AdsAndAnalyticsManager.Instance.Initialize();
        }
        
        public void CloseAgePanel() {
            _agePanel.SetActive(false);
        }
        
        void TogglePanel(GameObject panel) {
           var panelEffect = panel.GetComponent<PanelEffect>();
           if (panelEffect.Hidden) {
               panelEffect.Show();
           }
           else {
               panelEffect.Hide();
           }
        }
        
        void TogglePanel(GameObject panel, bool on) {
            var panelEffect = panel.GetComponent<PanelEffect>();
            if (on) {
                panelEffect.ShowFromCurrentPos();
            }
            else {
                panelEffect.HideFromCurrentPos();
            }   
        }


        void SetPanelsActiveness() {
           SetPanelActiveness(_infoPanel, _elementsActiveness.infoPanelActive);
           SetPanelActiveness(_settingsPanel, _elementsActiveness.settingsPanelActive);
           SetPanelActiveness(_tutPanel, _elementsActiveness.tutorialPanelActive);
           SetPanelActiveness(_pausePanel, _elementsActiveness.pausePanelActive);
           SetPanelActiveness(_topPanel, _elementsActiveness.topPanelActive);
        }

        void SetPanelActiveness(GameObject panel, bool active) {
          if(panel != null) panel.SetActive(active);
        }
    }
}