using System;
using UnityEngine;

namespace Game {
    public class TestInput: MonoBehaviour {

        [SerializeField] Transform _world;
        [SerializeField] float _rotationCoefficient;
        [SerializeField] Transform _ship;



        Vector3 _left = new Vector3(0, -10, 10);
        Vector3 _right = new Vector3(0, 10, -10);
        float _rotation;

        void Start() {
          //  _steering.OnRotating += SetRotation;
        }

        void Update() {
           // Debug.Log("Rotation: " + _rotation);
           _rotation = -SteeringWheel.steeringInput*2.5f;
            _ship.rotation = Quaternion.Euler(Vector3.zero);
            _world.Rotate(Vector3.up, _rotation);

            if (_rotation < 0) {
                _ship.rotation = Quaternion.Euler(_left);
            }

            if (_rotation > 0) {
                _ship.rotation = Quaternion.Euler(_right);
            }

            /*
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
            */
        }

        void SetRotation(float rot) {
            //_rotation = rot*0.02f;
            
        }
        
        
    }
}