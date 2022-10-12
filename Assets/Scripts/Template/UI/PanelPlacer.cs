using System;
using UnityEngine;

namespace UtilityScripts
{
    public enum PanelPosition
    {
        Top, 
        Bot
    }
    public class PanelPlacer: MonoBehaviour
    {
        [SerializeField] PanelPosition _panelPosition;
        [SerializeField] float _percentsOfScreen;
        private void Awake() {
            var rt = GetComponent<RectTransform>();
            float safeAreaHeight = Screen.safeArea.height;
            
            rt.sizeDelta = new Vector2(rt.sizeDelta.x, safeAreaHeight * (_percentsOfScreen/100));
            
            float posY = rt.rect.height / 2;;
            if (_panelPosition == PanelPosition.Top)
            {
                posY = -rt.rect.height / 2;
            }
            else {
                posY =  rt.rect.height / 2;
            }
            rt.anchoredPosition = new Vector3(rt.anchoredPosition.x, posY);
        }
    }
}