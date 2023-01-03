using System;
using System.Collections.Generic;
using Game;
using UnityEngine;

namespace GameNew {
    public class SectionMover {

        public event Action<Section> OnSectionShouldSpawn;
        public event Action<Section> OnSectionShouldBeDisabled;


        List<Section> _sectionsToMove;


        public void AddSection(Section section) {
            _sectionsToMove.RemoveAt(0);
            _sectionsToMove.Add(section);
        }
        
        void MoveSections() {
            
        }
        
    }
}