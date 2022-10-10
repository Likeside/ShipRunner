using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Utilities {
    public class SettingsPanel: MonoBehaviour {
        [SerializeField] Button _enBtn;
        [SerializeField] Button _ruBtn;
        [SerializeField] Button _sound;
        [SerializeField] List<Image> _soundBtnImgs;
        [SerializeField] TextSetter _versionText;
        
        IEnumerator Start() {
            
            _enBtn.onClick.RemoveAllListeners();
            _ruBtn.onClick.RemoveAllListeners();
            _sound.onClick.RemoveAllListeners();
            
            _enBtn.onClick.AddListener( () => { TextLoader.Instance.SwitchLocalization(Localization.EN); });
            _ruBtn.onClick.AddListener((() => {TextLoader.Instance.SwitchLocalization(Localization.RU);}));
            _sound.onClick.AddListener(ToggleSound);
            if (!PlayerPrefs.HasKey("audio")) {
                PlayerPrefsHelper.SetBool("audio", true);
            }
            _soundBtnImgs[0].enabled = PlayerPrefsHelper.GetBool("audio");
            _soundBtnImgs[1].enabled = !PlayerPrefsHelper.GetBool("audio");


            yield return new WaitForFixedUpdate();
            _versionText.Append(LevelTracker.Version + " (C) 2022 - " + DateTime.Now.Year);
        }

        void ToggleSound() {
            PlayerPrefsHelper.SetBool("audio", !PlayerPrefsHelper.GetBool("audio"));
            Debug.Log("Toggled sound: " + PlayerPrefsHelper.GetBool("audio"));
            _soundBtnImgs[0].enabled = PlayerPrefsHelper.GetBool("audio");
            _soundBtnImgs[1].enabled = !PlayerPrefsHelper.GetBool("audio");
        }
    }
}