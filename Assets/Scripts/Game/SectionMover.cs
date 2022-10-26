using System;
using System.Collections.Generic;
using UnityEngine;

namespace Game {
    public class SectionMover: MonoBehaviour {
        [SerializeField] Transform _parent;
        [SerializeField] List<GameObject> _spawnedSections;

        public event Action<Section> OnNewSectionSpawned;
        
        SectionsConfigSO _sectionsConfigSo;
        Transform _nextPosition;
        SectionSpawner _sectionSpawner;

       public void Initialize(SectionsConfigSO sectionsConfigSo) {
            _sectionsConfigSo = sectionsConfigSo;
            _nextPosition = _spawnedSections[^1].GetComponent<Section>().NextSectionSpawnPos;
            _sectionSpawner = new SectionSpawner(_sectionsConfigSo);
        }
        
        public void Update() {
            var backDirection = (_parent.InverseTransformDirection(Vector3.back)).normalized; 
            foreach (var spawnedSection in _spawnedSections) {
                spawnedSection.transform.localPosition += backDirection * Time.deltaTime * _sectionsConfigSo.speed;
            }

            if (!(_spawnedSections[^1].transform.localPosition.z <= 200)) return;
            var newSection = _sectionSpawner.GetNextSection(_spawnedSections[^1]);
            newSection.transform.SetParent(_parent);
            newSection.transform.rotation = _nextPosition.rotation;
            newSection.transform.position = _nextPosition.position;
            var sectionMb = newSection.GetComponent<Section>();
            OnNewSectionSpawned?.Invoke(sectionMb);
            _nextPosition = sectionMb.NextSectionSpawnPos;
            _spawnedSections.Add(newSection);
            _sectionSpawner.DisableSection(_spawnedSections[0]);
            _spawnedSections[0].transform.SetParent(null);
            _spawnedSections.Remove(_spawnedSections[0]);
        }
    }
}