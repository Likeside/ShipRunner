using System;
using UnityEngine;

namespace Game {
    public class TestInput: MonoBehaviour {

        [SerializeField] Transform _world;
        [SerializeField] float _rotationCoefficient;
        
        void Update() {
            if (Input.GetKey(KeyCode.A)) {
                //turn left
                _world.Rotate(Vector3.up, _rotationCoefficient);
            }

            if (Input.GetKey(KeyCode.D)) {
                //turn right
                _world.Rotate(Vector3.up, -_rotationCoefficient);
            }
        }
        
        
    }
}