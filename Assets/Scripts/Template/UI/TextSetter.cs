using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Utilities {
    public class TextSetter: MonoBehaviour {
        [SerializeField] string _textKey;
        Text _text;
        string _defaultTextKey;
        List<string> _appends;
        void Start() {
            _text = GetComponent<Text>();
            _text.font = TextLoader.Instance.Font;
            if (_textKey != null || _textKey != String.Empty) {
                _text.text = TextLoader.Instance.Texts[_textKey ?? string.Empty];
            }
        }

        public void Init() {
            _text = GetComponent<Text>();
            _text.font = TextLoader.Instance.Font;
            if (_textKey != null || _textKey != String.Empty) {
                _text.text = TextLoader.Instance.Texts[_textKey ?? string.Empty];
            }
        }
        public void SetText(string textKey) {
            _defaultTextKey = textKey;
            if (TextLoader.Instance.Texts[textKey] == null) {
                Debug.Log("TEXTKEY NULL");
            }

            if (_text == null) {
                Debug.Log("TEXT NULL");
                _text = GetComponent<Text>();
            }

            if (_text == null) {
                Debug.Log("STILL NULL");
            }
            _text.text = TextLoader.Instance.Texts[textKey];
        }


        public void Append(string text) {
            if (_appends == null) {
                _appends = new List<string>();
            }
            _appends.Add(text);
            if (_text == null) {
                Debug.Log("TEXT NULL");
                _text = GetComponent<Text>();
            }
            _text.text += text;
        }

        public void SetTextManually(string text) {
            if (_text == null) {
                Debug.Log("TEXT NULL");
                _text = GetComponent<Text>();
            }
            _text.text = text;
        }


        public void Refresh() {
            if (_text != null) {
                if (_textKey != null || _textKey != String.Empty) {
                    _text.text = TextLoader.Instance.Texts[_textKey ?? string.Empty];
                }

                if (_defaultTextKey != null) {
                    _text.text = TextLoader.Instance.Texts[_defaultTextKey ?? string.Empty];
                }

                if (_appends != null) {
                    foreach (var append in _appends) {
                        _text.text += append;
                    }
                }
            }
        }
    }
}