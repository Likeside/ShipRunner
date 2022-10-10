using System.Collections;
using DG.Tweening;
using UnityEngine;

namespace Utilities {

    public enum PanelEffectsShow {
        ShowSlideFromTop,
        ShowSlideFromLeft,
        ShowSlideFromRight,
        ShowSlideFromBot,
        ShowScale,
    }

    public enum PanelEffectsHide {
        HideSlideToTop,
        HideSlideToLeft,
        HideSlideToRight,
        HideSlideToBot,
        HideScale
    }
    public class PanelEffect: MonoBehaviour {

        [SerializeField] PanelEffectsShow _showEffect;
        [SerializeField] PanelEffectsHide _hideEffect;
        [SerializeField] Ease _ease;
        [SerializeField] RectTransform _targetPosRt;
        [SerializeField] bool _shownByDefault;


        public bool Hidden { get; private set; }
        
        RectTransform _rt;

        Vector2 _topSlidePos;
        Vector2 _botSlidePos;
        Vector2 _leftSlidePos;
        Vector2 _rightSlidePos;
        Vector2 _targetPos;
        
        IEnumerator Start() {
            yield return new WaitForFixedUpdate();
            _rt = GetComponent<RectTransform>();
            var sizeDelta = new Vector2(Screen.width*2, Screen.height*2);
            var anchoredPos = _rt.anchoredPosition;
            _topSlidePos = new Vector2(anchoredPos.x, (float) Screen.height / 2 + sizeDelta.y + 1);
            _botSlidePos = new Vector2(anchoredPos.x, -(float) Screen.height / 2 - sizeDelta.y - 1);
            _leftSlidePos = new Vector2(-(float) Screen.width / 2 - sizeDelta.x - 1, anchoredPos.y);
            _rightSlidePos = new Vector2((float) Screen.width / 2 + sizeDelta.x + 1, anchoredPos.y);
            _targetPos = _targetPosRt.anchoredPosition;
            if (!_shownByDefault) { 
                HideImmediately();
                Hidden = true;
            }
        }

        public void Show() {
            Hidden = false;
            switch (_showEffect) {
                case PanelEffectsShow.ShowScale: Scale(Vector3.one);
                    break;
                case PanelEffectsShow.ShowSlideFromBot: Slide(_botSlidePos, _targetPos);
                    break;
                case PanelEffectsShow.ShowSlideFromLeft: Slide(_leftSlidePos, _targetPos);
                    break;
                case PanelEffectsShow.ShowSlideFromRight: Slide(_rightSlidePos, _targetPos);
                    break;
                case PanelEffectsShow.ShowSlideFromTop: Slide(_topSlidePos, _targetPos);
                    break;
            }
        }


        public void Hide() {
            Hidden = true;
            switch (_hideEffect) {
                case PanelEffectsHide.HideScale: Scale(Vector3.zero);
                    break;
                case PanelEffectsHide.HideSlideToBot: Slide(_targetPos, _botSlidePos);
                    break;
                case PanelEffectsHide.HideSlideToLeft: Slide(_targetPos, _leftSlidePos);
                    break;
                case PanelEffectsHide.HideSlideToRight: Slide(_targetPos, _rightSlidePos);
                    break;
                case PanelEffectsHide.HideSlideToTop: Slide(_targetPos, _topSlidePos);
                    break;
            }
        }

        public void ShowFromCurrentPos() {
            Hidden = false;
            switch (_showEffect) {
                case PanelEffectsShow.ShowScale: Scale(Vector3.one);
                    break;
                case PanelEffectsShow.ShowSlideFromBot: Slide(transform.position, _targetPos);
                    break;
                case PanelEffectsShow.ShowSlideFromLeft: Slide(transform.position, _targetPos);
                    break;
                case PanelEffectsShow.ShowSlideFromRight: Slide(transform.position, _targetPos);
                    break;
                case PanelEffectsShow.ShowSlideFromTop: Slide(transform.position, _targetPos);
                    break;
            }
        }

        public void HideFromCurrentPos() {
            Hidden = true;
            switch (_hideEffect) {
                case PanelEffectsHide.HideScale: Scale(Vector3.zero);
                    break;
                case PanelEffectsHide.HideSlideToBot: Slide(_rt.anchoredPosition, _botSlidePos);
                    break;
                case PanelEffectsHide.HideSlideToLeft: Slide(_rt.anchoredPosition, _leftSlidePos);
                    break;
                case PanelEffectsHide.HideSlideToRight: Slide(_rt.anchoredPosition, _rightSlidePos);
                    break;
                case PanelEffectsHide.HideSlideToTop: Slide(_rt.anchoredPosition, _topSlidePos);
                    break;
            }  
        }
        
        void HideImmediately() {
            switch (_hideEffect) {
                case PanelEffectsHide.HideScale: _rt.localScale = Vector3.zero;
                    break;
                case PanelEffectsHide.HideSlideToBot: _rt.anchoredPosition = _botSlidePos;
                    break;
                case PanelEffectsHide.HideSlideToLeft: _rt.anchoredPosition = _leftSlidePos;
                    break;
                case PanelEffectsHide.HideSlideToRight: _rt.anchoredPosition = _rightSlidePos;
                    break;
                case PanelEffectsHide.HideSlideToTop: _rt.anchoredPosition = _topSlidePos;
                    break;
            }
        }

        void Slide(Vector2 start, Vector2 end) {
            gameObject.SetActive(true);
            _rt.anchoredPosition = start;
            _rt.localScale = Vector3.one;
            _rt.DOLocalMove(end, PanelManager.Instance.PanelEffectsConfigSo.panelSlideTime).SetEase(_ease).SetUpdate(true);;
           
        }

        void Scale(Vector3 target) {
            gameObject.SetActive(true);
            _rt.anchoredPosition = _targetPos;
            _rt.DOScale(target, PanelManager.Instance.PanelEffectsConfigSo.panelScaleTime).SetEase(_ease).SetUpdate(true);;
        }
    }
}