using System;
using UnityEngine;

namespace Game {
    public class Ship: MonoBehaviour {
        [SerializeField] float _rotationMultiplier;
        Vector3 _rotation = Vector3.zero;
        void Update() {
            _rotation.y = -SteeringWheel.steeringInput*_rotationMultiplier;
            _rotation.z = SteeringWheel.steeringInput*_rotationMultiplier;
            transform.rotation = Quaternion.Euler(_rotation);
        }
    }
}