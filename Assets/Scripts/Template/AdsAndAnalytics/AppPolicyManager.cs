
using UnityEngine;

namespace Utilities {
	
	public class AppPolicyManager {
    
		// Singleton stuff
		public static AppPolicyManager Instance => s_instance;
		static readonly AppPolicyManager s_instance = new AppPolicyManager();
		static AppPolicyManager() {}

		AppPolicyManager() {
			Init();
		}
		
		// Accessors
		public bool AppPolicyAccepted => _appPolicyAccepted;
		public int Age => _userAge;
		public bool HasTargetedAdsConsent => _hasTargetedAdsConsent;
		
		// Private vars
		bool _appPolicyAccepted;
		int _userAge;
		bool _hasTargetedAdsConsent;
		
		// Const
		const string k_userAge = "userAge";
		const string k_appPolicyAccepted = "appPolicyAccepted";
		const string k_hasTargetedAdsConsent = "hasTargetedAdsConsent";
		
		// ---------------------------------------------------------------
		// Initialization

		void Init() {
			_userAge = PlayerPrefs.GetInt(k_userAge, 0);
			_appPolicyAccepted = PlayerPrefsHelper.GetBool(k_appPolicyAccepted);
			_hasTargetedAdsConsent = PlayerPrefsHelper.GetBool(k_hasTargetedAdsConsent);
		}

		// ---------------------------------------------------------------
		// General methods

		public void SetAdsConsent(bool hasConsent) {
			if (_hasTargetedAdsConsent != hasConsent) {
				_hasTargetedAdsConsent = hasConsent;
				PlayerPrefsHelper.SetBool(k_hasTargetedAdsConsent, _hasTargetedAdsConsent);
				PlayerPrefs.Save();
			}
		}

		public void SetUserAge(int age) {
			if (age is > 0 and <= 99) {
				_userAge = age;
				PlayerPrefs.SetInt(k_userAge, _userAge);
				PlayerPrefs.Save();
			}
		}

		public bool UserIsChild() {
			return _userAge <= 13;
		}

		public bool UserHasProvidedAge() {
			return _userAge != 0;
		}

		public void AcceptAppPolicy() {
			_appPolicyAccepted = true;
			PlayerPrefsHelper.SetBool(k_appPolicyAccepted, _appPolicyAccepted);
			PlayerPrefs.Save();
		}

	}
}
