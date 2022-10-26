using System.Collections.Generic;
using UnityEngine;

namespace Game {
    public class Section: MonoBehaviour {
        [SerializeField] PossibleSections _type;
        [SerializeField] Transform _nextSectionSpawnPos;
        [SerializeField] List<PossibleSections> _possibleSectionTypes;

        public PossibleSections Type => _type;
        public Transform NextSectionSpawnPos => _nextSectionSpawnPos;
        public List<PossibleSections> PossibleSectionTypes => _possibleSectionTypes;
        
        
    }
}