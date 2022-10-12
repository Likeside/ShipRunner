using Template.UI;
using UnityEngine;
using Utilities;

public class GameController : LocalSingleton<GameController> {
        
        [SerializeField] ButtonManager _buttonManager;


        void Start() { 
               // SceneLoader.Instance.BsFadeIn();
                if (_buttonManager.TipButtonActive) _buttonManager.OnTipButtonPressed += ShowTip;
        }

        void ShowTip() {
                Debug.Log("Tip should be shown");
        }
}
