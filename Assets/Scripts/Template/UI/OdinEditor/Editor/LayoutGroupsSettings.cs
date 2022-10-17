using System.Linq;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.UI;

namespace Template.UI {
    
    [ExecuteInEditMode]
    public class LayoutGroupsSettings: MonoBehaviour {
        [SerializeField] bool _isLandscape;
        
        
        [Button]
        public void CopyCurrentGroupData() {
            var layoutGroups = FindObjectsOfType<HorizontalOrVerticalLayoutGroup>(true);
            foreach (var group in layoutGroups) {
               var data = group.gameObject.AddComponent<LayoutGroupData>();
               data.CopyData(_isLandscape);
            }
        }

        [Button]
        public void SetData() {
            var layoutGroups = FindObjectsOfType<HorizontalOrVerticalLayoutGroup>(true);
            foreach (var group in layoutGroups) {
                var data = group.gameObject.GetComponents<LayoutGroupData>().FirstOrDefault(d => d.IsLandscape == _isLandscape);
                if (data != null) {
                    data.SetData();
                }
                else {
                    Debug.Log("Some of the datas are absent, aborting");
                }
            }
        }

        [Button]
        public void DeleteLayoutGroupDatas() {
            var datas = FindObjectsOfType<LayoutGroupData>();
            foreach (var data in datas) {
                DestroyImmediate(data);
            }
        }
    }
}