using System;
using Unity.Services.Core;
using Unity.Services.Core.Environments;
using UnityEngine;

namespace Template.AdsAndAnalytics {
    public class InitializeUGS {
        
        public string environment = "production";
 
        async void Start() {
            try {
                var options = new InitializationOptions()
                    .SetEnvironmentName(environment);
 
                await UnityServices.InitializeAsync(options);
            }
            catch (Exception exception) {
                // An error occurred during initialization.
                Debug.Log("Smth is wrong with initialization of UGS: " + exception.Message);
            }
        }
        
    }
}