using UnityEngine;

namespace Game {
    public class SectionSpawner {

        PoolerBase<PossibleSections> _pooler;
        public SectionSpawner(SectionsConfigSO sectionsConfigSo) {
            _pooler = new PoolerBase<PossibleSections>(sectionsConfigSo.sectionDatas, 3);
        }
        
       public GameObject GetNextSection(GameObject currentSection) {
            var section = currentSection.GetComponent<Section>();
            int index = Random.Range(0, section.PossibleSectionTypes.Count);
            var type = section.PossibleSectionTypes[index];
            return _pooler.SpawnFromPool(type);
       }

       public void DisableSection(GameObject section) {
           _pooler.ReturnToPool(section);
       }
    }
}