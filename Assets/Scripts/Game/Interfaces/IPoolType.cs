using System;

namespace Game {
    public interface IPoolType<T> where T: Enum {
        public T Type { get; }
    }
}