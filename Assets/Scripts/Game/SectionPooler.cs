using System.Collections.Generic;
using System.Linq;
using Game;
using UnityEngine;

namespace GameScripts {
    public class SectionPooler {
        
        Dictionary<PossibleSections, Queue<GameObject>> _objsQueues;
        SectionsConfigSO _sectionsConfigSo;

        public SectionPooler(SectionsConfigSO sectionsConfigSo, int amount) {
            _sectionsConfigSo = sectionsConfigSo;
            _objsQueues = new Dictionary<PossibleSections, Queue<GameObject>>();
            foreach (var sectionData in sectionsConfigSo.SectionDatas) {
                var queue = new Queue<GameObject>();
                for (int i = 0; i < amount; i++) {
                    queue.Enqueue(GameObject.Instantiate(sectionData.section));
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
                     GameObject.Instantiate((_sectionsConfigSo.SectionDatas.FirstOrDefault(s => s.type == type))?.section));
             }
             var obj = _objsQueues[type].Dequeue(); 
             obj.SetActive(true);
             return obj;
        }
        public T SpawnFromPoolComp<T>(PossibleSections type) where T : Component {
            var queue = _objsQueues[type];
            if (queue.Count == 0) {
                queue.Enqueue(
                    GameObject.Instantiate((_sectionsConfigSo.SectionDatas.FirstOrDefault(s => s.type == type))?.section));
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