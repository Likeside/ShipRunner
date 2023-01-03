using System;
using System.Collections.Generic;
using Game;
using UnityEngine;

namespace GameNew {
    public class SectionMover {

        public event Action<Section> OnSectionShouldSpawn;
        public event Action<Section> OnSectionShouldBeDisabled;


        Transform _sectionParent;
        Transform _nextPosition;
        List<Section> _sectionsToMove;
        float _speed;


        public SectionMover(Transform sectionParent, float speed) {
            _sectionParent = sectionParent;
            _speed = speed;
        }

        public void AddSection(Section section) {
            section.transform.SetParent(_sectionParent);
            section.transform.rotation = _nextPosition.rotation;
            section.transform.position = _nextPosition.position;
            _nextPosition = section.NextSectionSpawnPos;
            _sectionsToMove.Add(section);
        }


        void DisableFirstSection() {
            _sectionsToMove[0].transform.SetParent(null);
            OnSectionShouldBeDisabled?.Invoke(_sectionsToMove[0]);
            _sectionsToMove.RemoveAt(0);
        }
        
        void MoveSections() {
            var backDirection = (_sectionParent.InverseTransformDirection(Vector3.back)).normalized; 
            foreach (var section in _sectionsToMove) {
                section.transform.localPosition += backDirection * Time.deltaTime * _speed;
            }
            
            if (!(_sectionsToMove[^1].transform.localPosition.z <= 160)) return;
            OnSectionShouldSpawn?.Invoke(_sectionsToMove[^1]);
        }
        
    }
}