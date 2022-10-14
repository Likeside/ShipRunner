using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using TMPro;
using UnityEngine;

namespace Utilities {

    public enum Localization {
        RU,
        EN, 
        Test
    }
    public class TextLoader : GlobalSingleton<TextLoader> {

        [SerializeField] Font _font;
        [SerializeField] TMP_FontAsset _tmpFont;

        public Dictionary<string, string> Texts { get; private set; }
        public Font Font => _font;
        public TMP_FontAsset TMPFont => _tmpFont;
      
      public Localization CurrentLocalization { get; private set; }

        protected override void OnSingletonAwake() {
           Set();
        }


       public void Set() {
            if (PlayerPrefs.GetString("lang") == String.Empty) {

                if (Application.systemLanguage == SystemLanguage.English) {
                    LoadTextAsset("Localization/ENJSON");
                    CurrentLocalization = Localization.EN;
                }
                else if (Application.systemLanguage == SystemLanguage.Russian) {
                    LoadTextAsset("Localization/RUJSON");
                    CurrentLocalization = Localization.RU;
                }
                else {
                    LoadTextAsset("Localization/ENJSON");
                    CurrentLocalization = Localization.EN;
                }
            }
            else {
                if (PlayerPrefs.GetString("lang") == "En") {
                    LoadTextAsset("Localization/ENJSON");
                    CurrentLocalization = Localization.EN;
                }
                else if (PlayerPrefs.GetString("lang") == "Ru") {
                    LoadTextAsset("Localization/RUJSON");
                    CurrentLocalization = Localization.RU;
                }
                else {
                    LoadTextAsset("Localization/ENJSON");
                    CurrentLocalization = Localization.EN;
                }
            }
        }
       
        void LoadTextAsset(string path) {
            var jsonText = Resources.Load<TextAsset>(path);
            if (jsonText == null) {
            }
            Texts = JsonConvert.DeserializeObject<Dictionary<string, string>>(jsonText.text);
        }
        void LoadFontAsset(string path) { 
         //   Font = Resources.Load<Font>(path);
        // Font = Resources.GetBuiltinResource(typeof(Font), "Arial.ttf") as Font;
        }
        void LoadTMPFontAsset(string path) {
          //  TMPFont = Resources.Load<TMP_FontAsset>(path);
        }
        
      public void SwitchLocalization(Localization localization) {
          Debug.Log("Switchting");
            if (localization == Localization.RU) {
                CurrentLocalization = Localization.RU;
                PlayerPrefs.SetString("lang", "Ru");
                LoadTextAsset("Localization/RUJSON");
            }
            else if (localization == Localization.EN){
                CurrentLocalization = Localization.EN;
                PlayerPrefs.SetString("lang", "En");
                LoadTextAsset("Localization/ENJSON");
            }
            else if (localization == Localization.Test) {
                CurrentLocalization = Localization.Test;
                PlayerPrefs.SetString("lang", "Test");
                LoadTextAsset("Localization/Test");
            }
            
            var textSetters = FindObjectsOfType<TextSetter>(true);
            foreach (var textSetter in textSetters) {
               // textSetter.Init();
                textSetter.Refresh();
            }
            
            var textSettersMesh = FindObjectsOfType<TextSetterMesh>(true);
            foreach (var textSetter in textSettersMesh) {
                // textSetter.Init();
                textSetter.Refresh();
            }


            var underlines = FindObjectsOfType<CustomUnderline>(true);
            foreach (var underline in underlines) {
                underline.Set();
            }
      }
    }
}