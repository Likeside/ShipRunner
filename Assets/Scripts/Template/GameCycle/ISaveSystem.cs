using System;

namespace Template.GameCycle {


    public enum SaveSystemType {
        Binary,Json
    }
    public interface ISaveSystem {
        public void SaveGame();
        public SaveData LoadGame();
        public void ClearData();
    }
}