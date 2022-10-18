using System;
using UnityEngine;
using UnityEngine.UI;
using Utilities;

namespace Template.Utilities {
    public class AudioBtnSubscriber: LocalSingleton<AudioBtnSubscriber> {

        Button[] _buttons;

        protected override void OnSingletonAwake() {
         
        }

        void Start() {
            
            _buttons = FindObjectsOfType<Button>(true);
            Debug.Log("Found buttons: " + _buttons.Length);
            if (_buttons != null) {
                foreach (var btn in _buttons) {
                    btn.onClick.RemoveListener(AudioManager.Instance.PlayTapSound);
                }
            }
            if (_buttons != null) {
                foreach (var btn in _buttons) { 
                    Debug.Log("AddingListener");
                    btn.onClick.AddListener(AudioManager.Instance.PlayTapSound);
                }
            }
            
        }
    }
}