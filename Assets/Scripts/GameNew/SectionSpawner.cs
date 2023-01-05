using System;
using System.Collections.Generic;
using Game;
using UnityEngine;
using Zenject;
using Random = UnityEngine.Random;

namespace GameNew {
    public class SectionSpawner {
        
        public event Action<Section> OnSectionSpawned;
        public event Action<Section> OnSectionDisabled;

        PoolerBase<PossibleSections> _sectionPooler;

        Vector3 _leftSidePos;
        Vector3 _rightSidePos;

        
        public SectionSpawner(SectionsConfigSO sectionsConfigSo, IGameplayConfig gameplayConfig, List<Section> initSections) {
            _sectionPooler = new PoolerBase<PossibleSections>(sectionsConfigSo.sectionDatas, 3);
            _leftSidePos = new Vector3(-gameplayConfig.SectionsWidth, 0, 0);
            _rightSidePos = -_leftSidePos;
            Debug.Log("Constructing spawner: " + _leftSidePos + ":" + _rightSidePos + "; sectionswidth:" + gameplayConfig.SectionsWidth);
            foreach (var section in initSections) {
                section.SetSectionWidth(_leftSidePos, _rightSidePos);
            }
        }

        public void SpawnSection(Section lastSection) {
            int index = Random.Range(0, lastSection.PossibleSectionTypes.Count);
            var type = lastSection.PossibleSectionTypes[index];
            var newSection = _sectionPooler.SpawnFromPool(type).GetComponent<Section>();
            newSection.SetSectionWidth(_leftSidePos, _rightSidePos);
            OnSectionSpawned?.Invoke(newSection);
        }

        public void DisableSection(Section sectionToDisable) {
            _sectionPooler.ReturnToPool(sectionToDisable.gameObject);
            OnSectionDisabled?.Invoke(sectionToDisable);
        }
    }
}