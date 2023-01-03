using System;
using Game;
using UnityEngine;
using Random = UnityEngine.Random;

namespace GameNew {
    public class SectionSpawner {
        
        public event Action<Section> OnSectionSpawned;
        public event Action<Section> OnSectionDisabled;

        PoolerBase<PossibleSections> _sectionPooler;

        
        public SectionSpawner(SectionsConfigSO sectionsConfigSo) {
            _sectionPooler = new PoolerBase<PossibleSections>(sectionsConfigSo.sectionDatas, 3);
        }

        public void SpawnSection(Section lastSection) {
            int index = Random.Range(0, lastSection.PossibleSectionTypes.Count);
            var type = lastSection.PossibleSectionTypes[index];
            var newSection = _sectionPooler.SpawnFromPool(type).GetComponent<Section>();
            OnSectionSpawned?.Invoke(newSection);
        }

        public void DisableSection(Section sectionToDisable) {
            _sectionPooler.ReturnToPool(sectionToDisable.gameObject);
            OnSectionDisabled?.Invoke(sectionToDisable);
        }
    }
}