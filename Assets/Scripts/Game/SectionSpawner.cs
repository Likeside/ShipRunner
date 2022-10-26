using System.Linq;
using GameScripts;
using UnityEngine;

namespace Game {
    public class SectionSpawner {

        SectionPooler _sectionPooler;
        public SectionSpawner(SectionsConfigSO sectionsConfigSo) {
            _sectionPooler = new SectionPooler(sectionsConfigSo, 3);
        }
        
       public GameObject GetNextSection(GameObject currentSection) {
            var section = currentSection.GetComponent<Section>();
            int index = Random.Range(0, section.PossibleSectionTypes.Count);
            var type = section.PossibleSectionTypes[index];
            return _sectionPooler.SpawnFromPool(type);
       }
    }
}