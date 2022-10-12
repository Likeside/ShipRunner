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
             Set();
        }
        
        public void SetText(string textKey) {
            _text.text = TextLoader.Instance.Texts[textKey];
        }

        public void Set(bool isEditor = false, TextLoader textLoader = null) {
            if (_isGUI) {
                if (isEditor) {
                    _textGUI = GetComponent<TextMeshProUGUI>();
                    if(textLoader.InstanceForEditorScripts() == null) Debug.Log("Instance null1");
                    _textGUI.font = textLoader.InstanceForEditorScripts().TMPFont;
                    if (_textKey != null) {
                        if(textLoader.InstanceForEditorScripts() == null) Debug.Log("Instance null2");
                        if(textLoader.InstanceForEditorScripts().Texts == null || textLoader.InstanceForEditorScripts().Texts.Count < 1) Debug.Log("Did not load texts");
                        _textGUI.text = textLoader.InstanceForEditorScripts().Texts[_textKey];
                    }
                }
                else {
                    _textGUI = GetComponent<TextMeshProUGUI>();
                    _textGUI.font = TextLoader.Instance.TMPFont;
                    if (_textKey != null) {
                        _textGUI.text = TextLoader.Instance.Texts[_textKey];
                    }
                }
               
            }
            else {
                if (isEditor) {
                    _text = GetComponent<TextMeshPro>();
                    _text.font = textLoader.InstanceForEditorScripts().TMPFont;
                    if (_textKey != null) {
                        _text.text = textLoader.InstanceForEditorScripts().Texts[_textKey];
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