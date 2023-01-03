using System;
using System.Collections.Generic;
using Game;
using UnityEngine;
using Zenject;

namespace GameNew {
    public class SectionController: MonoBehaviour {

        [SerializeField] SectionsConfigSO _sectionsConfigSo;
        [SerializeField] Transform _sectionsParent;
        [SerializeField] List<Section> _initSections;
        
        SectionSpawner _spawner;
        SectionMover _mover;
        SectionFiller _filler;


        [Inject]
        public void Construct (IGameplayConfig gameplayConfig) {

            _mover = new SectionMover(_initSections, _sectionsParent, gameplayConfig.SectionsSpeed);
            _spawner = new SectionSpawner(_sectionsConfigSo);
            _filler = new SectionFiller(_sectionsConfigSo, _initSections, gameplayConfig.CoinRotationSpeed);

            _mover.OnSectionShouldSpawn += _spawner.SpawnSection;
            _mover.OnSectionShouldBeDisabled += _spawner.DisableSection;
            
            _spawner.OnSectionSpawned += _mover.AddSection;
            _spawner.OnSectionSpawned += _filler.FillSection;
            
            _spawner.OnSectionDisabled += _filler.ClearSection;
            
        }

        void Update() {
            _mover.MoveSections();
        }
    }
}