using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiHider : MonoBehaviour {

    [SerializeField] List<GameObject> _uiObjects;
    [SerializeField] KeyCode _keyCode;

    bool _uiActive = true;
    void Update()
    {
        if (Input.GetKeyDown(_keyCode)) {
            ToggleUi();
        }
    }

    void ToggleUi() {
        _uiActive = !_uiActive;
        foreach (var uiObj in _uiObjects) {
            uiObj.SetActive(_uiActive);
        }
    }
}
