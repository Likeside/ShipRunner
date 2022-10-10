using System;
using UnityEngine;

namespace Utilities
{
    public class CameraCalculator: LocalSingleton<CameraCalculator> {
        [SerializeField] public RectTransform _topPanel;

        [SerializeField] public RectTransform _botPanel;
        //Screen size
        public float ScreenWidthHalved { get; private set; }
        public float ScreenHeightHalved { get; private set; }
        
        public float ScreenWidth { get; private set; }
        public float ScreenHeight { get; private set; }
        
        //SafeAreaSize
        public float SafeAreaWidthHalved { get; private set; }
        public float SafeAreaHeightHalved { get; private set; }
        
        public float SafeAreaWidth { get; private set; }
        public float SafeAreaHeight { get; private set; }
        
        
        public float TopPanelYCorner { get; private set; }
        
        public float BotPanelYCorner { get; private set; }
        
        
        public float GameAreaHeight { get; private set; }
        
        public float yPosCenter { get; private set; }
        
        public event Action OnCalculated;


        void Awake() {
            Initialize();
        }

      public void Initialize() {
            var mainCamera = Camera.main;
            ScreenHeightHalved = mainCamera.orthographicSize;
            ScreenWidthHalved = mainCamera.aspect * mainCamera.orthographicSize;

            ScreenHeight = ScreenHeightHalved * 2;
            ScreenWidth = ScreenWidthHalved * 2;
            
            
            SafeAreaHeightHalved = ConvertPixelsToWorldUnits(Screen.safeArea.height / 2);
            SafeAreaWidthHalved = ConvertPixelsToWorldUnits(Screen.safeArea.width / 2);


            SafeAreaHeight = SafeAreaHeightHalved * 2;
            SafeAreaWidth = SafeAreaWidthHalved * 2;
            
            
            Vector3[] botPanelCorners = new Vector3[4];
            _botPanel.GetWorldCorners(botPanelCorners);
            BotPanelYCorner = botPanelCorners[1].y;
            
            Vector3[] topPanelCorners = new Vector3[4];
            _topPanel.GetWorldCorners(topPanelCorners);
            TopPanelYCorner = topPanelCorners[0].y;
            Debug.Log("TopYCornerSet " + TopPanelYCorner);


            GameAreaHeight = TopPanelYCorner - BotPanelYCorner;

            yPosCenter = BotPanelYCorner + GameAreaHeight / 2;
            
            OnCalculated?.Invoke();
        }


        float ConvertPixelsToWorldUnits(float pixels) { 
            float camOrthoSize = Camera.main.orthographicSize;
            float pixelHeight = Camera.main.scaledPixelHeight;
            
            return (pixels * camOrthoSize * 2) / pixelHeight;
        }
        
        
    }
}