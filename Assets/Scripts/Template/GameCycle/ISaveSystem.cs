using System;

namespace Template.GameCycle {
    public interface ISaveSystem {
        public void SaveGame();
        public SaveData LoadGame();
        public void ClearData();
    }
}