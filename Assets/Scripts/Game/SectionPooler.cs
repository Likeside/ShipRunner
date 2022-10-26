using System.Collections.Generic;
using System.Linq;
using Game;
using UnityEngine;

namespace GameScripts {
    public class SectionPooler {
        
        Dictionary<PossibleSections, Queue<GameObject>> _objsQueues;

       List<SectionsConfigSO.PoolData<PossibleSections>> _datas;
      //  SectionsConfigSO _sectionsConfigSo;

        public SectionPooler(List<SectionsConfigSO.PoolData<PossibleSections>> poolDatas, int amount) {
            _datas = poolDatas;
            _objsQueues = new Dictionary<PossibleSections, Queue<GameObject>>();
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
         public GameObject SpawnFromPool(PossibleSections type) {

             var queue = _objsQueues[type];
             if (queue.Count == 0) {
                 queue.Enqueue(
                     GameObject.Instantiate((_datas.FirstOrDefault(s => s.type == type))?.prefab));
             }
             var obj = _objsQueues[type].Dequeue(); 
             obj.SetActive(true);
             return obj;
        }
        public T SpawnFromPoolComp<T>(PossibleSections type) where T : Component {
            var queue = _objsQueues[type];
            if (queue.Count == 0) {
                queue.Enqueue(
                    GameObject.Instantiate((_datas.FirstOrDefault(s => s.type == type))?.prefab));
            }
            var obj = _objsQueues[type].Dequeue(); 
            obj.SetActive(true);
            return obj.GetComponent<T>();
        }
        public void ReturnToPool(GameObject obj) {
            var type = obj.GetComponent<Section>().Type;
            _objsQueues[type].Enqueue(obj);
            obj.SetActive(false);
        }
    }
}