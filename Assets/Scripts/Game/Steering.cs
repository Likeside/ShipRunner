using System;
using UnityEngine;

namespace Game {
    public class Steering: MonoBehaviour {
         [SerializeField] PanAndZoom _panAndZoom;

         [SerializeField] Transform _steer;
       // [SerializeField] Rigidbody2D _rb;
       // [SerializeField] float _speed;

       public event Action<float> OnRotating;
        
        Vector2 _pos;
        Vector2 _firstTouch;
        void Start() {
            _panAndZoom.controlCamera = false;
            _panAndZoom.onStartTouch += SetFirstTouch;
            _panAndZoom.onEndTouch += ResetTouch;
            _panAndZoom.onSwipe += Rotate;
           // _pos = transform.position;
           _pos = Camera.main.WorldToScreenPoint(Vector3.zero);
           Debug.Log("Pos: " + _pos);
        }

        void ResetTouch(Vector2 touchEnd) {
            Debug.Log("Reset " + touchEnd);
            _firstTouch = Vector2.zero;
        }
        
        void SetFirstTouch(Vector2 touchPos) {
            Debug.Log("TouchPos " + touchPos);
           // _firstTouch = Camera.main.ScreenToWorldPoint(touchPos);
         // _firstTouch = Camera.main.ScreenToViewportPoint(touchPos);
         _firstTouch = touchPos;
         Debug.Log("First touch: " + _firstTouch);
        }
        void Rotate(Vector2 rot) {
            Debug.Log("Rotation vector: " + rot);
            var swipe = Mathf.Abs(Mathf.Abs(rot.y) > Mathf.Abs(rot.x) ? rot.y : rot.x);
            Debug.Log("Swipe: " + swipe + "; FirstTouch: " + _firstTouch);
            if (_firstTouch.x < _pos.x && _firstTouch.y > _pos.y) {
                //topLeft
                if(rot.y > 0 && rot.x < 0) return;
                if(rot.y < 0 && rot.x > 0) return;
                if (rot.y > 0 && rot.x > 0) {
                    RotateRight(swipe);
                }
                if (rot.y < 0 && rot.x < 0) {
                    RotateLeft(swipe);
                }
            }
            if (_firstTouch.x > _pos.x && _firstTouch.y > _pos.y) {
                //topRight
                if(rot.y > 0 && rot.x > 0) return;
                if(rot.y < 0 && rot.x < 0) return;
                if (rot.y < 0 && rot.x > 0) {
                    RotateRight(swipe);
                }
                if (rot.y > 0 && rot.x < 0) {
                    RotateLeft(swipe);
                }
            }
            if (_firstTouch.x < _pos.x && _firstTouch.y < _pos.y) {
                //botLeft
                if(rot.y < 0 && rot.x < 0) return;
                if(rot.y > 0 && rot.x > 0) return;
                if (rot.y > 0 && rot.x < 0) {
                    RotateRight(swipe);
                }
                if (rot.y < 0 && rot.x > 0) {
                    RotateLeft(swipe);
                }
            }
            if (_firstTouch.x > _pos.x && _firstTouch.y < _pos.y) {
                //botRight
                if(rot.y < 0 && rot.x > 0) return;
                if(rot.y > 0 && rot.x < 0) return;
                if (rot.y < 0 && rot.x < 0) {
                    RotateRight(swipe);
                }
                if (rot.y > 0 && rot.x > 0) {
                    RotateLeft(swipe);
                }
            }
        }
        
        void RotateLeft(float swipe) {
          //  _rb.MoveRotation(_rb.rotation + _speed*swipe*Time.fixedDeltaTime);
          Debug.Log("Invoking rotation left");
          _steer.Rotate(Vector3.back, -swipe*0.1f);
            OnRotating?.Invoke(-swipe);
        }
        
        void RotateRight(float swipe) { 
            // _rb.MoveRotation(_rb.rotation - _speed*swipe*Time.fixedDeltaTime);
            Debug.Log("Invoking rotation right");
            _steer.Rotate(Vector3.back, swipe*0.1f);
            OnRotating?.Invoke(swipe);
        }
    }
}