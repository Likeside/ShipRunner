using System;
using System.Collections.Generic;
using System.Linq;
using LeTai.TrueShadow;
using UnityEngine;
using UnityEngine.UI;
using Sirenix.OdinInspector;
using Template.UI;
//using UnityEditor;

namespace Utilities.OdinEditor {
    
    [ExecuteInEditMode]
    public class RectSettings: MonoBehaviour {
        
        public bool IsLandscape => _isLandscape;
        [SerializeField] bool _isLandscape;
        [SerializeField] List<RectTransformSingleSettings> _singleRects;
        [PropertySpace(SpaceBefore = 10, SpaceAfter = 30)]
        [SerializeField] List<RectTransformGroupSettings> _groupRects;

        [HorizontalGroup("single")]
        public string singleRectName;
        [HorizontalGroup("single")]
        [Button]
        public void AddSingleRect() {
            _singleRects.Add(new RectTransformSingleSettings(singleRectName));
            singleRectName = String.Empty;
        }

        [HorizontalGroup("group")]
        public string rectGroupName;
        [HorizontalGroup("group")]
        [Button]
        public void AddGroupRects() {
            _groupRects.Add(new RectTransformGroupSettings(rectGroupName));
            rectGroupName = String.Empty;
        }
        
        void Update() {
            /*
            if(EditorApplication.isPlaying ) return;
            foreach (var setting in _singleRects) {
                setting.SetSettings();
            } 
            foreach (var setting in _groupRects) {
                setting.SetSettings();
            }
            */
        }
        
        #region RectTransformsSettings
        
        [Serializable]
        public abstract class RectTransformSettings {
            [HideInInspector]
            [SerializeField] string _header;
            [Title("$_header", Bold = true)]
            [Vector2Slider(0, 2566)]
            public Vector2 rectSize;
            public Color _color;
            [HorizontalGroup("Fields")]
            [VerticalGroup("Fields/Group")] 
            [LabelWidth(80)]
            public Image.Type imageType;
            [VerticalGroup("Fields/Group")] 
            [LabelWidth(80)]
            public AnchorPresets anchor;
            [VerticalGroup("Fields/Group")] 
            [LabelWidth(80)]
            public PivotPresets pivot;
            protected RectTransformSettings(string header) {
                _header = header;
                _color = Color.white;
            }
            public abstract void SetSettings();
            [VerticalGroup("Fields/Group")]
            [Button]
            public abstract void GetImageComponent();

            [VerticalGroup("Fields/Group")]
            [HorizontalGroup("Fields/Group/Shadow")]
            [Button]
            public abstract void AddShadow();

            [VerticalGroup("Fields/Group")]
            [HorizontalGroup("Fields/Group/Shadow")]
            [Button]
            public abstract void RemoveShadow();
        }

        
        [Serializable]
        public class RectTransformGroupSettings: RectTransformSettings {
            [HorizontalGroup("RectsAndTextures")]
            public List<RectTransform> rects;
            [HorizontalGroup("RectsAndTextures")]
            public List<Sprite> textures;
            List<Image> images;
            public RectTransformGroupSettings(string header) : base(header) {
            }
            public override void SetSettings() {
                foreach (var rect in rects) {
                    rect.sizeDelta = rectSize;
                    if(anchor != AnchorPresets.Ignore) rect.SetAnchor(anchor);
                    if(pivot != PivotPresets.Ignore) rect.SetPivot(pivot);
                }
                if (images != null && images.Count > 0) {
                    for (int i = 0; i < images.Count; i++) {
                        images[i].type = imageType;
                        if (textures.Count > 0) {
                            images[i].sprite = textures[0];
                        }
                        if (i < textures.Count) {
                            images[i].sprite = textures[i];
                        }
                        images[i].color = _color;
                    }
                }
            }
            public override void GetImageComponent() {
                if (!rects.Any()) {
                    Debug.Log("No rects added to the list");
                    return;
                }
                images = new List<Image>();
                foreach (var rect in rects) {
                   images.Add(rect.GetComponent<Image>()); 
                }
            }

            public override void AddShadow() {
                foreach (var rect in rects) {
                   var shadow = rect.gameObject.GetComponent<TrueShadow>();
                   if (shadow == null) {
                       rect.gameObject.AddComponent<TrueShadow>();
                   }
                }
            }

            public override void RemoveShadow() {
                foreach (var rect in rects) {
                    var shadow = rect.gameObject.GetComponent<TrueShadow>();
                    if (shadow != null) {
                        DestroyImmediate(shadow);
                    }
                }
            }
        }
        
        [Serializable]
        public class RectTransformSingleSettings: RectTransformSettings{
            [VerticalGroup("Fields/Group")]
            [LabelWidth(80)]
            public RectTransform rect; 
            [VerticalGroup("Fields/Group")]
            [LabelWidth(80)]
            public Image image;
            [HorizontalGroup("Fields", 100)]
            [PreviewField(80, ObjectFieldAlignment.Left)]
            [HideLabel]
            public Sprite _texture;
            public RectTransformSingleSettings(string header) : base(header) {
            }
            public override void SetSettings() {
                if (image != null) {
                    image.type = imageType;
                    image.color = _color;
                    image.sprite = _texture;
                }
                rect.sizeDelta = rectSize;
                if(anchor != AnchorPresets.Ignore) rect.SetAnchor(anchor);
                if(pivot != PivotPresets.Ignore) rect.SetPivot(pivot);
            }
            [Button]
            public override void GetImageComponent() {
                if (rect == null) {
                    Debug.Log("Rect is null");
                    return;
                }
                image = rect.GetComponent<Image>();
            }

            public override void AddShadow() {
                
            }

            public override void RemoveShadow() {
                
            }
        }
        #endregion
    }
}