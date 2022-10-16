using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.UI;

namespace Template.UI {
    
    [ExecuteInEditMode]
    public class LayoutGroupsSettings: MonoBehaviour {
        [SerializeField] bool _isLandScape;
        
        
        [Button]
        public void CopyGroupData() {
            var layoutGroups = FindObjectsOfType<HorizontalOrVerticalLayoutGroup>(true);
            foreach (var group in layoutGroups) {
               var data = group.gameObject.AddComponent<LayoutGroupData>();
               data.CopyData();
            }
            
        }
    }
}