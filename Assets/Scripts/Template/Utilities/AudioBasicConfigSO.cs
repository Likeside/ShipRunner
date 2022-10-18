using UnityEngine;

namespace Utilities {
    [CreateAssetMenu(fileName = "AudioBasicConfigSO", menuName = "Configs/AudioBasicConfigSO", order = 5)]
    public class AudioBasicConfigSO: ScriptableObject {
        public AudioClip btnClick;
    }
}