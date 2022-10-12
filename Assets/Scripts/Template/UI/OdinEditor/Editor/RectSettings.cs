using System;
using System.Collections.Generic;
using System.Linq;
using PlasticGui;
using UnityEngine;
using UnityEngine.UI;
using Sirenix.OdinInspector;
using UnityEditor;

namespace Utilities.OdinEditor {
    
    [ExecuteInEditMode]
    public class RectSettings: MonoBehaviour {


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
            if(EditorApplication.isPlaying ) return;
            foreach (var setting in _singleRects) {
                setting.SetSettings();
            } 
            foreach (var setting in _groupRects) {
                setting.SetSettings();
            }
        }



        [Serializable]
        public abstract class RectTransformSettings {
            string _header;
            [Title("$_header", Bold = true)] 

            [Vector2Slider(0, 2566)]
            public Vector2 _rectSize;
            public Color _color;
            
            [VerticalGroup("Fields/Group")] 
            [LabelWidth(80)]
            public Image.Type imageType;

            protected RectTransformSettings(string header) {
                _header = header;
                _color = Color.white;
            }
            
            public abstract void SetSettings();
            
            [VerticalGroup("Fields/Group")]
            [Button]
            public abstract void GetImageComponent();
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
                    rect.sizeDelta = _rectSize;
                }
                if (images != null && images.Count > 0) {
                    for (int i = 0; i < images.Count; i++) {
                        images[i].type = imageType;
                        images[i].sprite = textures[i];
                        images[i].color = _color;
                    }
                    /*
                    foreach (var image in images) {
                        image.type = imageType;
                        image.sprite = _texture;
                        image.color = _color;
                    }
                    */
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
                rect.sizeDelta = _rectSize;
            }

            [Button]
            public override void GetImageComponent() {
                if (rect == null) {
                    Debug.Log("Rect is null");
                    return;
                }
                image = rect.GetComponent<Image>();
            }

            
        }
    }
}