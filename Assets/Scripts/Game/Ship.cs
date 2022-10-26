using System;
using UnityEngine;

namespace Game {
    public class Ship: MonoBehaviour {
        [SerializeField] float _rotationMultiplier;


        public event Action OnCollidedWithObstacle;
        
        Vector3 _rotation = Vector3.zero;
        void Update() {
            _rotation.y = -SteeringWheel.steeringInput*_rotationMultiplier;
            _rotation.z = SteeringWheel.steeringInput*_rotationMultiplier;
            transform.rotation = Quaternion.Euler(_rotation);
        }


        void OnTriggerEnter(Collider other) {
            Debug.Log("Colliding");
            if (other.transform.TryGetComponent(out ICollectable collectable) ) {
                collectable.Collect();
            }

            if (other.transform.TryGetComponent(out Obstacle obstacle)) {
                OnCollidedWithObstacle?.Invoke();
            }
        }
    }
}