using UnityEngine;

namespace Utilities {
    [CreateAssetMenu(fileName = "AndsAndAnalyticsConfigSO", menuName = "Configs/AdsAndAnalyticsConfigSO", order = 5)]
    public class AdsAndAnalyticsConfigSO: ScriptableObject {
        [Header("Android")]
        public string androidID;
        public string androidRewarded;
        public string androidInterstitial;
        public string androidBanner;
        
        [Header("iOS")]
        public string iosID;
        public string iosRewarded;
        public string iosInterstitial;
        public string iosBanner;

        [Header("Settings")]
        public int interstitialFrequency;

        [Header("Links")] 
        public string termsLink;
        public string policyLink;


    }
}