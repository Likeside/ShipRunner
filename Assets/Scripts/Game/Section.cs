using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Game {
    public class Section: MonoBehaviour, IPoolType<PossibleSections> {
        [SerializeField] PossibleSections _type;
        [SerializeField] Transform _nextSectionSpawnPos;
        [SerializeField] List<PossibleSections> _possibleSectionTypes;

        [SerializeField] List<Vector3> _collectablePositions;
        [SerializeField] List<Vector3> _towerPositions;
        [SerializeField] List<Vector3> _towerRotations;

        [SerializeField] Transform _leftSide;
        [SerializeField] Transform _rightSide;
        [SerializeField] bool _inversedSides;
        
        public PossibleSections Type => _type;
        public Transform NextSectionSpawnPos => _nextSectionSpawnPos;
        public List<PossibleSections> PossibleSectionTypes => _possibleSectionTypes;
        
        public List<Vector3> CollectablePositions => _collectablePositions;
        public List<Vector3> TowerPosition => _towerPositions;
        public List<Vector3> TowerRotations => _towerRotations;

        public List<GameObject> Coins { get; } = new();

        public void SetSectionWidth(Vector3 leftSidePos, Vector3 rightSidePos) {
            if (_inversedSides) {
                _leftSide.localPosition = rightSidePos;
                _rightSide.localPosition = leftSidePos;
            }
            else {
                _leftSide.localPosition = leftSidePos;
                _rightSide.localPosition = rightSidePos;
            }
        }

        [Button]
        public void SetCollectablePositions() {
            _collectablePositions = new List<Vector3>();
            foreach (Transform child in transform) {
                if (child.TryGetComponent(out ICollectable collectable)) {
                    _collectablePositions.Add(child.localPosition);
                }
            }
        }

        [Button]
        public void SetTowerPositionsAndRotations() {
            _towerPositions = new List<Vector3>();
            _towerRotations = new List<Vector3>();
            foreach (Transform child in transform) {
                if (child.TryGetComponent(out Tower tower)) {
                    _towerPositions.Add(tower.transform.localPosition);
                    _towerRotations.Add(tower.transform.localRotation.eulerAngles);
                }
            }
        }
    }
}