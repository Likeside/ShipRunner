using System;
using UnityEngine;

namespace Game {
    public class TestInput: MonoBehaviour {

        [SerializeField] Transform _world;
        [SerializeField] float _rotationCoefficient;
        [SerializeField] Transform _ship;


        Vector3 _left = new Vector3(0, -10, -10);
        Vector3 _right = new Vector3(0, 10, 10);
        void Update() {
            
            _ship.rotation = Quaternion.Euler(Vector3.zero);
            
            if (Input.GetKey(KeyCode.A)) {
                //turn left
                _world.Rotate(Vector3.up, _rotationCoefficient);
                _ship.rotation = Quaternion.Euler(_left);
            }

            if (Input.GetKey(KeyCode.D)) {
                //turn right
                _world.Rotate(Vector3.up, -_rotationCoefficient);
                _ship.rotation = Quaternion.Euler(_right);
            }
        }
        
        
    }
}