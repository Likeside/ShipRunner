using System;
using UnityEngine;
using UnityEngine.UI;

namespace Game {
    
    public enum TowerType {
        Simple
    }
    public class TowerController {

        public event Action OnTowerFired;
        PoolerBase<TowerType> _pooler;
        CannonInputController _cannonInputController;

        public TowerController(SectionsConfigSO sectionsConfigSo, CannonInputController cannonInputController) {
            _cannonInputController = cannonInputController;
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
                tower.OnTowerFired += TowerFired;
                tower.OnTowerSectionDisabled += ReturnTowerToPool;
                _cannonInputController.OnFiringLeft += tower.ReceiveFireLeft;
                _cannonInputController.OnFiringRight += tower.ReceiveFireRight;
                section.OnSectionDisabled += tower.SectionDisabled; //!!!отписаться (отписка в секции)
                //ПЕРЕПИСАТЬ НАХУЙ ЭТО ГОВНО
            }
        }

        void ReturnTowerToPool(Tower tower) {
            Debug.Log("Returning tower to pool");
            tower.Unsubscribe();
            _cannonInputController.OnFiringLeft -= tower.ReceiveFireLeft;
            _cannonInputController.OnFiringRight -= tower.ReceiveFireRight;
            _pooler.ReturnToPool(tower.gameObject);
        }

        void TowerFired(Tower tower) {
            Debug.Log("Towe fired from tower controller");
            ReturnTowerToPool(tower);
            OnTowerFired?.Invoke();
        }
    }
}