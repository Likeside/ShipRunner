using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Game {
    public class CannonsParticles: MonoBehaviour {
        [SerializeField] List<ParticleGroup> _leftExplosions;
        [SerializeField] List<ParticleGroup> _rightExplosions;
        
        IInputController _inputController;
        
        [Inject]
        public void Construct(IInputController inputController) {
            _inputController = inputController;
            _inputController.OnFiringLeft += FireLeft;
            _inputController.OnFiringRight += FireRight;
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
            _inputController.OnFiringLeft -= FireLeft;
            _inputController.OnFiringRight -= FireRight;
        }
    }
}