using System;

namespace Game {
    public interface IInputController {
        public event Action OnFiringLeft;
        public event Action OnFiringRight;
        public float SteeringInput { get; }
    }
}