using System;

namespace Game {
    public interface IInputController {
        public event Action OnFireLeft;
        public event Action OnFireRight;
        public float SteeringInput { get; }
    }
}