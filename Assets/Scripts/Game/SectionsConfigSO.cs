using System;
using System.Collections.Generic;
using GameNew.Enums;
using UnityEngine;

namespace Game {
    [CreateAssetMenu(fileName = "SectionsConfigSO", menuName = "Configs/SectionsConfigSO", order = 5)]
    public class SectionsConfigSO: ScriptableObject {

        public float speed;

       // [NonReorderable] 
       // public List<SectionData> SectionDatas;

        [NonReorderable] 
        public List<PoolData<PossibleSections>> sectionDatas;
        [NonReorderable] 
        public List<PoolData<CoinType>> coinDatas;
        [NonReorderable] 
        public List<PoolData<TowerType>> towerDatas;
    }
    
    [Serializable]
    public class PoolData<T> where T : Enum {
        public GameObject prefab;
        public T type;
    }
}