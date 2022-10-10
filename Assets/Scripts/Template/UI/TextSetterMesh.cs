using System;
using TMPro;
using UnityEngine;

namespace Utilities {
    public class TextSetterMesh: MonoBehaviour {
        [SerializeField] string _textKey;
        [SerializeField] bool _isGUI;
        TextMeshPro _text;
        TextMeshProUGUI _textGUI;

        void Start() {
            if (_isGUI) {
                _textGUI = GetComponent<TextMeshProUGUI>();
                _textGUI.font = TextLoader.Instance.TMPFont;
                if (_textKey != null) {
                    _textGUI.text = TextLoader.Instance.Texts[_textKey];
                }
            }
            else {
                _text = GetComponent<TextMeshPro>();
                _text.font = TextLoader.Instance.TMPFont;
                if (_textKey != null) {
                    _text.text = TextLoader.Instance.Texts[_textKey];
                }
            }
        }
        
        public void SetText(string textKey) {
            _text.text = TextLoader.Instance.Texts[textKey];
        }
        
        public void Refresh() {
            if (_text != null) {
                if (_textKey != null || _textKey != String.Empty) {
                    _text.text = TextLoader.Instance.Texts[_textKey ?? string.Empty];
                }
            }
        }
    }
}