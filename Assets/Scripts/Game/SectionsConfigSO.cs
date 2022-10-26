using System;
using System.Collections.Generic;
using UnityEngine;

namespace Game {
    [CreateAssetMenu(fileName = "SectionsConfigSO", menuName = "Configs/SectionsConfigSO", order = 5)]
    public class SectionsConfigSO: ScriptableObject {

        public float speed;

        public GameObject goldCoin;
        public GameObject silverCoin;
        public GameObject bronzeCoin;
        [NonReorderable] 
        public List<SectionData> SectionDatas;
        
        [Serializable]
        public class SectionData {
            public GameObject section;
            public PossibleSections type;
        }
    }
}