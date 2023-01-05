namespace Game {
    public interface IGameplayConfig {
        public float SectionsSpeed { get; }
        public float FireRate { get; }
        public float WorldRotationSpeed { get; }
        public float ShipRotationMultiplier { get; }
        
        public float TailParticlesRotationMultiplier { get; }
        
        public float CoinRotationSpeed { get; }
        public float SectionsWidth { get; }
    }
}