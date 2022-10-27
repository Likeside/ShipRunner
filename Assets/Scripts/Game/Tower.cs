using System;
using System.Collections;
using UnityEngine;

namespace Game {
    public class Tower: MonoBehaviour, IPoolType<TowerType> {

        [SerializeField] Transform _towerCenter;
        public TowerType Type => TowerType.Simple;
        public event Action<Tower> OnTowerDestroyed;
        public event Action<Tower> OnTowerSectionDisabled;
        public event Action<Tower> OnTowerFired;

        bool _fired;


        void Update() {
            if(_fired) return;
            if (_towerCenter.position.z < -5.1f) {
                Fire();
            }
        }

        public void SectionDisabled() {
            if (gameObject.activeSelf) {
                _fired = false;
                OnTowerSectionDisabled?.Invoke(this);
                Unsubscribe();
            }
        }

        public void Unsubscribe() {
            _fired = false;
            OnTowerDestroyed = null;
            OnTowerSectionDisabled = null;
            OnTowerFired = null;
        }

        void DestroyTower() {
            _fired = false;
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

        void Fire() {
            _fired = true;
            StartCoroutine(PlayFireAnimation());
        }

        IEnumerator PlayFireAnimation() {
            Debug.Log("Playing fire animation");
            yield return new WaitForSeconds(0.3f); //TODO: ЗАМЕНИТЬ НА НОРМ ХУЙНЮ
            OnTowerFired?.Invoke(this);
        }
        
        IEnumerator PlayDestroyAnimation() {
            Debug.Log("playing destroy animation");
            yield return new WaitForSeconds(0.3f); //TODO: ЗАМЕНИТЬ НА НОРМ ХУЙНЮ
            OnTowerDestroyed?.Invoke(this);
        }
    }
}