using UnityEngine;

namespace GameNew {
    
    [CreateAssetMenu(fileName = "GameplayConfigSO", menuName = "Configs/GameplayConfigSO", order = 8)]
    public class GameplayConfigSO: ScriptableObject {
        public float sectionSpeed;
        public float fireRate;
        public float worldRotationSpeed;
        public float shipRotationMultiplier;
        public float tailParticlesRotationMultiplier;
    }
}