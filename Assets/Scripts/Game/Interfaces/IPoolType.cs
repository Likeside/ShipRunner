using System;

namespace Game {
    public interface IPoolType<out T> where T: Enum {
        public T Type { get; }
    }
}