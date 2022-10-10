using UnityEngine;

namespace Utilities {
    [CreateAssetMenu(fileName = "PanelEffectsConfigSO", menuName = "Configs/PanelEffectsConfigSO", order = 5)]
    public class PanelEffectsConfigSO: ScriptableObject {
        public float panelSlideTime;
        public float panelScaleTime;
    }
}