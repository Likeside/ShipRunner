using System.Linq;
using UnityEngine;

namespace Game {
    public class SectionSpawner {

        SectionsConfigSO _sectionsConfigSo;
        public SectionSpawner(SectionsConfigSO sectionsConfigSo) {
            _sectionsConfigSo = sectionsConfigSo;
        }
        
       public GameObject GetNextSection(GameObject currentSection) {
            var section = currentSection.GetComponent<Section>();
            int index = Random.Range(0, section.PossibleSectionTypes.Count);
            var type = section.PossibleSectionTypes[index];
            return _sectionsConfigSo.SectionDatas.FirstOrDefault(s => s.type == type)?.section;
       }
    }
}