using UnityEngine;

namespace Game {
    public class TestSectionRotation {
        
       public GameObject GetNextSection(GameObject currentSection) {
            var section = currentSection.GetComponent<Section>();
            int index = Random.Range(0, section.PossibleSections.Count);
            return section.PossibleSections[index];
       }
    }
}