using System;
using Game;
using UnityEngine;

namespace GameNew {
    public class SectionSpawner {
        
        public event Action<Section> OnSectionSpawned;
        public event Action<Section> OnSectionDisabled;


        public void SpawnSection(Section sectionToDisable) {
            
        }

        void DisableSection(Section sectionToDisable) {
            
        }
    }
}