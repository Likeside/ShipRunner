using Game;
using GameNew.Enums;
using UnityEngine;

namespace GameNew {
    public class Morgenstern: MonoBehaviour, IPoolType<MorgensternTypes> {
        
        [SerializeField] Transform _center;
        [SerializeField] Animator _animator;
        [SerializeField] Collider _collider;
        
        static readonly int Destroy1 = Animator.StringToHash("Destroy");


        public MorgensternTypes Type { get; }

        public void Reset() {
            _animator.ResetTrigger(Destroy1);
            _collider.enabled = true;
        }
        
        bool IsInFireZone() {
            return _center.position.z is <= 5f and >= -5f;
        }
        
        public void ReceiveFireLeft() {
            if (IsInFireZone() && _center.position.x < 0) {
                DestroyThis();
            }
        }
        
        public void ReceiveFireRight() {
            if (IsInFireZone() && _center.position.x > 0) {
                DestroyThis();
            }   
        }
        
        void DestroyThis() {
            DisableCollider();
            PlayAnimation();
        }

        void PlayAnimation() {
            _animator.SetTrigger(Destroy1);
        }

        void DisableCollider() {
            _collider.enabled = false;
        }
    }
}