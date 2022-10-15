using System;
using Utilities;

namespace Template.GameCycle {
    
    [Serializable]
    public class SaveData {

        public int LevelToLoad { get; private set; }
        public SaveData() {
            LevelToLoad = LevelTracker.LevelToLoad;
        }
    }
}