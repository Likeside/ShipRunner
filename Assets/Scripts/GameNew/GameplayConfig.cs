using Game;
using UnityEngine;

namespace GameNew {
    public class GameplayConfig: MonoBehaviour, IGameplayConfig {
        [SerializeField] GameplayConfigSO _config;
        public float SectionsSpeed => _config.sectionSpeed;
        public float FireRate => _config.fireRate;
        public float WorldRotationSpeed => _config.worldRotationSpeed;
        public float ShipRotationMultiplier => _config.shipRotationMultiplier;
        public float TailParticlesRotationMultiplier => _config.tailParticlesRotationMultiplier;
        public float CoinRotationSpeed => _config.coinRotationSpeed;

        public float SectionsWidth => _config.sectionsWidth;
    }
}