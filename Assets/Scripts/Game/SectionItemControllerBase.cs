using System;

namespace Game {
    public class SectionItemControllerBase<T> where T: Enum {

        PoolerBase<T> _pooler;

        public SectionItemControllerBase(SectionsConfigSO configSo) {
           // _pooler = new PoolerBase<T>(configSo., 5);
        }

        public void SpawnItems(Section section, Action<IPoolType<T>> itemUsedCallback, T type) {
            
        }
    }
}