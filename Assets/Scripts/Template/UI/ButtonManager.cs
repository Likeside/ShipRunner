using UnityEngine;
using UnityEngine.UI;
using Utilities;

namespace Template.UI {
    public class ButtonManager: LocalSingleton<ButtonManager> {
        [SerializeField] Button _startBtn;
        [SerializeField] Button _quitButton;
    }
}