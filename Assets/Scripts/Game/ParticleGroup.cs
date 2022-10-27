using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Game {
    public class ParticleGroup: MonoBehaviour {
        List<ParticleSystem> _particleSystems;
        void Start() {
            _particleSystems = GetComponentsInChildren<ParticleSystem>().ToList();
        }

        public void Play() {
            foreach (var particles in _particleSystems) {
                particles.Play();
            }
        }
    }
}