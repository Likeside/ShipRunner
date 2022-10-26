using System;
using UnityEngine;

namespace Game {
    public class WorldRotation : MonoBehaviour {

        [SerializeField] Transform _world;
        [SerializeField] float _rotationCoefficient;
        
        float _rotation;
        
        void Update() {
            _rotation = -SteeringWheel.steeringInput * _rotationCoefficient;
            _world.Rotate(Vector3.up, _rotation);
        }
    }
}