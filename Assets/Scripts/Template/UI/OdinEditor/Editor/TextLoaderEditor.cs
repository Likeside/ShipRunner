using Sirenix.OdinInspector;
using UnityEngine;

namespace Utilities.OdinEditor {
    
    [ExecuteInEditMode]
    public class TextLoaderEditor: MonoBehaviour {
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
    }
}