using System;
using System.Collections;
using UnityEngine;

namespace Game {
    public class Tower: MonoBehaviour, IPoolType<TowerType> {

        [SerializeField] Transform _towerCenter;
        public TowerType Type { get; } = TowerType.Simple;
        public event Action<Tower> OnTowerDestroyed;
        public event Action<Tower> OnTowerSectionDisabled;

        bool _isInFireZone = false;

        public void SectionDisabled() {
            OnTowerSectionDisabled?.Invoke(this);
            Unsubscribe();
        }

        public void Unsubscribe() {
            OnTowerDestroyed = null;
            OnTowerSectionDisabled = null;
        }

        IEnumerator PlayDestroyAnimation() {
            Debug.Log("playing destroy animation");
            yield return new WaitForSeconds(0.3f); //TODO: ЗАМЕНИТЬ НА НОРМ ХУЙНЮ
            OnTowerDestroyed?.Invoke(this);
            Unsubscribe();
        }


        void OnTriggerEnter(Collider other) {
            _isInFireZone = true;
        }
        void DestroyTower() {
            _isInFireZone = false;
            StartCoroutine(PlayDestroyAnimation());
        }

        void OnTriggerExit(Collider other) {
            _isInFireZone = false;
        }


        public void ReceiveFireLeft() {
            if (_isInFireZone && _towerCenter.position.x < 0) {
                DestroyTower();
            }
        }

        public void ReceiveFireRight() {
            if (_isInFireZone && _towerCenter.position.x > 0) {
                DestroyTower();
            }   
        }

    }
}