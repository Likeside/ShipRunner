namespace GameNew {
    public class SectionController {


        SectionSpawner _spawner;
        SectionMover _mover;
        SectionFiller _filler;



        public SectionController() {

            _mover.OnSectionShouldSpawn += _spawner.SpawnSection;
            _spawner.OnSectionSpawned += _mover.AddSection;
            _spawner.OnSectionSpawned += _filler.FillSection;
            _spawner.OnSectionDisabled += _filler.EmptySection;



        }
    }
}