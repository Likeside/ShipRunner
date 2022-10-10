using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Utilities {
    public class Coroutiner: GlobalSingleton<Coroutiner> {


        public Coroutine StartCor(IEnumerator coroutine) {
          return StartCoroutine(coroutine);
        }

        public void StopCor(Coroutine coroutine) {
            StopCoroutine(coroutine);
        }

        public void StopCoroutines(List<Coroutine> coroutines) {
            foreach (var cor in coroutines) {
                if (cor != null) {
                    StopCoroutine(cor);
                }
            }
        }
    }
}