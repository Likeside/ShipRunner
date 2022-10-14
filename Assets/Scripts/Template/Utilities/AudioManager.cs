using UnityEngine;
using UnityEngine.UI;

namespace Utilities {
    public class AudioManager: LocalSingleton<AudioManager> {
        [SerializeField] Slider _volumeSlider;
        void Start() {
            _volumeSlider.onValueChanged.RemoveAllListeners();
            float currentVolume = PlayerPrefs.GetFloat("volume", 1f);
            _volumeSlider.value = currentVolume;
            AudioListener.volume = currentVolume;
            _volumeSlider.onValueChanged.AddListener(SetMasterVolume);
        }
        
        void SetMasterVolume(float value) {
            PlayerPrefs.SetFloat("volume", value);
            AudioListener.volume = PlayerPrefs.GetFloat("volume");
        }
    }
}