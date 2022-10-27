using System;
using System.Collections;
using UnityEngine;

namespace Game {
    public class Tower: MonoBehaviour {
        
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
            yield return new WaitForSeconds(1f); //TODO: ЗАМЕНИТЬ НА НОРМ ХУЙНЮ
            OnTowerDestroyed?.Invoke(this);
            Unsubscribe();
        }


        void OnTriggerEnter(Collider other) {
            _isInFireZone = true;
        }
        void DestroyTower() {
            StartCoroutine(PlayDestroyAnimation());
        }

        void OnTriggerExit(Collider other) {
            _isInFireZone = false;
        }


        public void ReceiveFireLeft() {
            if (_isInFireZone && transform.position.x < 0) {
                DestroyTower();
            }
        }

        public void ReceiveFireRight() {
            if (_isInFireZone && transform.position.x > 0) {
                DestroyTower();
            }   
        }

    }
}