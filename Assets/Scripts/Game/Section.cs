using System.Collections.Generic;
using UnityEngine;

namespace Game {
    public class Section: MonoBehaviour {
        [SerializeField] List<GameObject> _possibleSections ;

        public List<GameObject> PossibleSections => _possibleSections;
    }
}