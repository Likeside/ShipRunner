using System;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEditor;
using UnityEngine;

namespace Utilities.OdinEditor {
    
    [ExecuteInEditMode]
    public class TextLoaderEditor: MonoBehaviour {
        
        [SerializeField] List<TextSettingsPlain> _plainTexts;
        [PropertySpace(SpaceBefore = 10, SpaceAfter = 30)]
        [SerializeField] List<TextSettingsMesh> _textMeshes;
        
        [HorizontalGroup("plain")]
        public string plainText;
        [HorizontalGroup("single")]
        [Button]
        public void AddPlainText() {
            _plainTexts.Add(new TextSettingsPlain(plainText));
            plainText = String.Empty;
        }

        [HorizontalGroup("mesh")]
        public string textMesh;
        [HorizontalGroup("mesh")]
        [Button]
        public void AddTextMesh() {
            _textMeshes.Add(new TextSettingsMesh(textMesh));
            textMesh = String.Empty;
        }

        [VerticalGroup("TextsAndFonts")]
        [Button]
        public void SetTextFontFromTextLoader() {
            var texts = FindObjectsOfType<TextSetter>(true);
            var textsMeshes = FindObjectsOfType<TextSetterMesh>(true);
            var textLoader = FindObjectOfType<TextLoader>();
            textLoader.Set();
            foreach (var text in texts) {
                text.Set(true, textLoader);
            }
            foreach (var text in textsMeshes) {
                text.Set(true, textLoader);
            }
        }
        [HorizontalGroup("TextsAndFonts/Localization")]
        [Button]
        public void SwitchLocalization() {
            var textLoader = FindObjectOfType<TextLoader>();
            textLoader.Set();
            textLoader.SwitchLocalization(localization);
            SetTextFontFromTextLoader();
        }
        [HorizontalGroup("TextsAndFonts/Localization")] 
        [HideLabel]
        public Localization localization;

        
        void Update() {
            if(EditorApplication.isPlaying ) return;
            foreach (var setting in _plainTexts) {
                setting.SetSettings();
            } 
            foreach (var setting in _textMeshes) {
                setting.SetSettings();
            }
        }
        
        #region TextSettings
        [Serializable]
        public abstract class TextSettings {
            [HideInInspector]
            [SerializeField] string _header;
            
            public TextSettings(string header) {
                _header = header;
            }

            public abstract void SetSettings();
        }
        [Serializable]
        public class TextSettingsPlain: TextSettings {
            public TextSettingsPlain(string header) : base(header) {
            }

            public override void SetSettings() {
                throw new NotImplementedException();
            }
        }
        [Serializable]
        public class TextSettingsMesh: TextSettings {
            public TextSettingsMesh(string header) : base(header) {
            }

            public override void SetSettings() {
                throw new NotImplementedException();
            }
        }
        #endregion
    }
}