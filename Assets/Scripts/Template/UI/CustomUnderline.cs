using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Utilities {
    public class CustomUnderline: MonoBehaviour {
        IEnumerator Start() {
            yield return new WaitForFixedUpdate();
            Set();
        }
        
        public void Set() {
            float textSize;
            
            var text = GetComponentInParent<Text>();
            if (text == null) {
                var textMesh = GetComponentInParent<TextMeshProUGUI>();
                if(textMesh == null) return;
                textSize = textMesh.textBounds.size.x;
            }
            else {
                textSize = text.preferredWidth;
            }


            var rt = GetComponent<RectTransform>();
            rt.sizeDelta = new Vector2(textSize, rt.sizeDelta.y);
        }
    }
}