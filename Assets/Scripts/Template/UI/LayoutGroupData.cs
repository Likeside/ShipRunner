using System;
using UnityEngine;
using UnityEngine.UI;

namespace Template.UI {
    [Serializable]
    public class LayoutGroupData: MonoBehaviour {
        [SerializeField] bool _isLandscape;
        [SerializeField] int _paddingLeft;
        [SerializeField] int _paddingRight;
        [SerializeField] int _paddingTop;
        [SerializeField] int _paddingBottom;
        [SerializeField] float _spacing;
        [SerializeField] TextAnchor _childAlignment;
        [SerializeField] bool _reverseArrangement;
        [SerializeField] bool _controlChildWidth;
        [SerializeField] bool _controlChildHeight;
        [SerializeField] bool _useChildScaleWidth;
        [SerializeField] bool _useChildScaleHeight;
        [SerializeField] bool _controlChildForceExpandWidth;
        [SerializeField] bool _controlChildForceExpandHeight;

        public bool IsLandscape => _isLandscape;
        HorizontalOrVerticalLayoutGroup _group;
        
       public void SetData() {
            _group = GetComponent<HorizontalOrVerticalLayoutGroup>();
            _group.padding.left = _paddingLeft;
            _group.padding.right = _paddingRight;
            _group.padding.top = _paddingTop;
            _group.padding.bottom = _paddingBottom;
            _group.spacing = _spacing;
            _group.childAlignment = _childAlignment;
            _group.reverseArrangement = _reverseArrangement;
            _group.childControlWidth = _controlChildWidth;
            _group.childControlHeight = _controlChildHeight;
            _group.childScaleWidth = _useChildScaleWidth;
            _group.childScaleHeight = _useChildScaleHeight;
            _group.childForceExpandWidth = _controlChildForceExpandWidth;
            _group.childForceExpandHeight = _controlChildForceExpandHeight;
       }

       public void CopyData() {
           _group = GetComponent<HorizontalOrVerticalLayoutGroup>();
           _paddingLeft = _group.padding.left;
           _paddingRight = _group.padding.right;
           _paddingTop = _group.padding.top;
           _paddingBottom = _group.padding.bottom;
           _spacing = _group.spacing;
           _childAlignment = _group.childAlignment;
           _reverseArrangement = _group.reverseArrangement;
           _controlChildWidth = _group.childControlWidth;
           _controlChildHeight = _group.childControlHeight;
           _useChildScaleWidth = _group.childScaleWidth;
           _useChildScaleHeight = _group.childScaleHeight;
           _controlChildForceExpandWidth = _group.childForceExpandWidth;
           _controlChildForceExpandHeight = _group.childForceExpandHeight;
       }
    }
}