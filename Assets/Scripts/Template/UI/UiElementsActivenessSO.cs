using UnityEngine;

namespace Utilities.OdinEditor {
    
    [CreateAssetMenu(fileName = "UIElementsActivenessSO", menuName = "Configs/UIElementsActivenessSO", order = 5)]
    public class UiElementsActivenessSO: ScriptableObject {
        public bool settingsPanelActive = true;
        public bool infoPanelActive = true;
        public bool adminInterfaceActive;
        public bool topPanelActive = true;
        public bool tipButtonActive;
        public bool pauseButtonActive = true;
        public bool backButtonActive = true;
        public bool skipLevelButtonActive = true;
    }
}