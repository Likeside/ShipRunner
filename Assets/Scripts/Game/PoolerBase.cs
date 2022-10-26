using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Game {
    public class PoolerBase<T> where T: Enum {
               
          Dictionary<T, Queue<GameObject>> _objsQueues;

         List<SectionsConfigSO.PoolData<T>> _datas;
      //  SectionsConfigSO _sectionsConfigSo;

        public PoolerBase(List<SectionsConfigSO.PoolData<T>> poolDatas, int amount) {
            _datas = poolDatas;
            _objsQueues = new Dictionary<T, Queue<GameObject>>();
            foreach (var sectionData in poolDatas) {
                var queue = new Queue<GameObject>();
                for (int i = 0; i < amount; i++) {
                    var obj = GameObject.Instantiate(sectionData.prefab);
                    queue.Enqueue(obj);
                    obj.SetActive(false);
                }
                _objsQueues.Add(sectionData.type, queue);
            }
        }
        public void DisableAll() {
            foreach (var keyValue in _objsQueues) {
                foreach (var obj in keyValue.Value) {
                    obj.SetActive(false);
                }
            }
        }
         public GameObject SpawnFromPool(T type) {

             var queue = _objsQueues[type];
             if (queue.Count == 0) {
                 queue.Enqueue(
                     GameObject.Instantiate((_datas.FirstOrDefault(s => s.type.Equals(type)))?.prefab));
             }
             var obj = _objsQueues[type].Dequeue(); 
             obj.SetActive(true);
             return obj;
        }
        public TY SpawnFromPoolComp<TY>(T type) where TY : Component {
            var queue = _objsQueues[type];
            if (queue.Count == 0) {
                queue.Enqueue(
                    GameObject.Instantiate((_datas.FirstOrDefault(s => s.type.Equals(type)))?.prefab));
            }
            var obj = _objsQueues[type].Dequeue(); 
            obj.SetActive(true);
            return obj.GetComponent<TY>();
        }
        
        public void ReturnToPool(GameObject obj) {
            var type = obj.GetComponent<IPoolType<T>>().Type;
            _objsQueues[type].Enqueue(obj);
            obj.SetActive(false);
        }
    }
}