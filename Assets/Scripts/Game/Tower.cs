using System;
using System.Collections;
using UnityEngine;

namespace Game {
    public class Tower: MonoBehaviour, IPoolType<TowerType> {

        [SerializeField] Transform _towerCenter;
        public TowerType Type => TowerType.Simple;
        public event Action<Tower> OnTowerDestroyed;
        public event Action<Tower> OnTowerSectionDisabled;
        
        
        
        public void SectionDisabled() {
            if (gameObject.activeSelf) {
                OnTowerSectionDisabled?.Invoke(this);
                Unsubscribe();
            }
        }

        public void Unsubscribe() {
            OnTowerDestroyed = null;
            OnTowerSectionDisabled = null;
        }

        IEnumerator PlayDestroyAnimation() {
            Debug.Log("playing destroy animation");
            yield return new WaitForSeconds(0.3f); //TODO: ЗАМЕНИТЬ НА НОРМ ХУЙНЮ
            OnTowerDestroyed?.Invoke(this);
        }
        
        void DestroyTower() {
            StartCoroutine(PlayDestroyAnimation());
        }
        bool IsInFireZone() {
            return _towerCenter.position.z is <= 5f and >= -5f;
        }


        public void ReceiveFireLeft() {
            if (IsInFireZone() && _towerCenter.position.x < 0) {
                DestroyTower();
            }
        }

        public void ReceiveFireRight() {
            if (IsInFireZone() && _towerCenter.position.x > 0) {
                DestroyTower();
            }   
        }

    }
}