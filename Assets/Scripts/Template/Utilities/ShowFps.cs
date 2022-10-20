using System;
using TMPro;
using UnityEngine;

namespace Template.Utilities {
    public class ShowFps: MonoBehaviour { 
        TextMeshProUGUI _fpsText;    
        float _deltaTime;

        void Start() {
            _fpsText = GetComponent<TextMeshProUGUI>();
        }

        void Update () {
            _deltaTime += (Time.deltaTime - _deltaTime) * 0.1f;
            float fps = 1.0f / _deltaTime;
            _fpsText.text = Mathf.Ceil (fps).ToString ();
        }
    }
}