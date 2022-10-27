using System;
using UnityEngine;

namespace Game {
    
    public enum TowerType {
        Simple
    }
    public class TowerController {
        
        PoolerBase<TowerType> _pooler;
        
        public TowerController(SectionsConfigSO sectionsConfigSo) {
            _pooler = new PoolerBase<TowerType>(sectionsConfigSo.towerDatas, 5);
        }
        
        
        public void SpawnTowers(Section section, Action<Tower> towerDestroyedCallback, TowerType type = TowerType.Simple) {
            for (int i = 0; i < section.TowerPosition.Count; i++) {
                var tower = _pooler.SpawnFromPoolComp<Tower>(type);
                var tr = tower.transform;
                tr.SetParent(section.transform);
                tr.localPosition = section.TowerPosition[i];
                tr.localRotation = Quaternion.Euler(section.TowerRotations[i]);
                tower.OnTowerDestroyed += ReturnTowerToPool;
                tower.OnTowerDestroyed += towerDestroyedCallback;
            }
        }

        void ReturnTowerToPool(Tower tower) {
            tower.OnTowerDestroyed -= ReturnTowerToPool;
            _pooler.ReturnToPool(tower.gameObject);
        }
    }
}