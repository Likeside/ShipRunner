using System;
using System.Collections.Generic;
using UnityEngine;

namespace Game {
    public class TestSectionSpawner: MonoBehaviour {
        [SerializeField] Transform _parent;
        [SerializeField] GameObject _sectionPrefab;
        [SerializeField] float _speed;

        [SerializeField] List<GameObject> _spawnedSections;

        Transform _nextPosition;
        
        readonly Vector3 _newSectionPos = new(0, 0, 240);

        void Start() {
            _nextPosition = _spawnedSections[^1].transform.GetChild(0);
        }

        void Update() {
            //var direction = -_parent.transform.eulerAngles + Vector3.back;
            Debug.Log("Back direction: " + _parent.InverseTransformDirection(Vector3.back));
            var backDirection = (_parent.InverseTransformDirection(Vector3.back)).normalized; //+Vector3.back).normalized;
            foreach (var spawnedSection in _spawnedSections) {
                spawnedSection.transform.localPosition += backDirection * Time.deltaTime * _speed;
               // spawnedSection.transform.position += Vector3.back * Time.deltaTime * _speed;
            }

            if (_spawnedSections[^1].transform.localPosition.z <= 200) {
                //var newSection = Instantiate(_sectionPrefab, _newSectionPos, Quaternion.identity, _parent, false);
                var newSection = Instantiate(_sectionPrefab, _parent, false);
                newSection.transform.position = _nextPosition.position;
                _nextPosition = newSection.transform.GetChild(0);
                _spawnedSections.Add(newSection);
                Destroy(_spawnedSections[0]);
                _spawnedSections.Remove(_spawnedSections[0]);
            }
        }
    }
}