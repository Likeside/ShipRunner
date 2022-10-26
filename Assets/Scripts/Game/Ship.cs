using System;
using UnityEngine;

namespace Game {
    public class Ship: MonoBehaviour {
        Vector3 _rotation = Vector3.zero;
        void Update() {
            _rotation.y = SteeringWheel.steeringInput;
            _rotation.z = -SteeringWheel.steeringInput;
            transform.rotation = Quaternion.Euler(_rotation);
        }
    }
}