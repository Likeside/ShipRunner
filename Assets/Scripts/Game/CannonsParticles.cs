using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game {
    public class CannonsParticles: MonoBehaviour {
        [SerializeField] List<ParticleGroup> _leftExplosions;
        [SerializeField] List<ParticleGroup> _rightExplosions;
        [SerializeField] CannonInputController _cannonInputController;

        void Start() {
            _cannonInputController.OnFiringLeft += FireLeft;
            _cannonInputController.OnFiringRight += FireRight;
        }

        void FireRight() {
            StartCoroutine(ExplosionCor(_rightExplosions));
        }

        void FireLeft() {
            StartCoroutine(ExplosionCor(_leftExplosions));
        }

        IEnumerator ExplosionCor(List<ParticleGroup> explosions) {
            foreach (var explosion in explosions) {
                explosion.Play();
                yield return new WaitForSeconds(0.2f);
            }
        }


        void OnDestroy() {
            _cannonInputController.OnFiringLeft -= FireLeft;
            _cannonInputController.OnFiringRight -= FireRight;
        }
    }
}