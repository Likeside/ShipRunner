using System;
using System.Collections.Generic;
using UnityEngine;

namespace Game {
    public class SectionMoverX: MonoBehaviour {
        [SerializeField] Transform _parent;
        [SerializeField] List<GameObject> _spawnedSections;
        //[SerializeField] List<Transform> _waters;
        //[SerializeField] GameObject _waterPrefab;

        public event Action<Section> OnNewSectionSpawned;
        
        SectionsConfigSO _sectionsConfigSo;
        Transform _nextPosition;
        SectionSpawnerX _sectionSpawner;
        //Vector3 _waterInitLocalPos;

        public void Initialize(SectionsConfigSO sectionsConfigSo) {
            _sectionsConfigSo = sectionsConfigSo;
            _nextPosition = _spawnedSections[^1].GetComponent<Section>().NextSectionSpawnPos;
            _sectionSpawner = new SectionSpawnerX(_sectionsConfigSo);
           // _waterInitLocalPos =  new Vector3(_water.transform.localPosition.x, _water.transform.localPosition.y, _water.transform.localPosition.z);
        }
        
        
        public void Update() {
            var backDirection = (_parent.InverseTransformDirection(Vector3.back)).normalized; 
            foreach (var spawnedSection in _spawnedSections) {
                spawnedSection.transform.localPosition += backDirection * Time.deltaTime * _sectionsConfigSo.speed;
            }

            /*
            foreach (var water in _waters) {
                water.localPosition += backDirection * Time.deltaTime * _sectionsConfigSo.speed;
            }
            //_water.transform.localPosition = _waterInitLocalPos + backDirection * _sectionsConfigSo.speed; //*Time.deltaTime;
            //_water.transform.localPosition = _spawnedSections[3].transform.localPosition + Vector3.down;

            if (_waters[^1].transform.localPosition.z <= 200) {
                var newWater = Instantiate(_waterPrefab);
                newWater.transform.SetParent(_parent);
                newWater.transform.rotation = _nextPosition.rotation;
                newWater.transform.position = _nextPosition.position;
                _waters.Add(newWater.transform);
            }
            */
            
            
            if (!(_spawnedSections[^1].transform.localPosition.z <= 160)) return;
            var newSection = _sectionSpawner.GetNextSection(_spawnedSections[^1]);
            newSection.transform.SetParent(_parent);
            newSection.transform.rotation = _nextPosition.rotation;
            newSection.transform.position = _nextPosition.position;
            var sectionMb = newSection.GetComponent<Section>();
            OnNewSectionSpawned?.Invoke(sectionMb);
            _nextPosition = sectionMb.NextSectionSpawnPos;
            _spawnedSections.Add(newSection);
            _sectionSpawner.DisableSection(_spawnedSections[0].GetComponent<Section>());
            _spawnedSections[0].transform.SetParent(null);
            _spawnedSections.Remove(_spawnedSections[0]);
            
        }
    
    }
}