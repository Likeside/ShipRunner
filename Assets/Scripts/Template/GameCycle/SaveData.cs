using Utilities;

namespace Template.GameCycle {
    public class SaveData {

        public int LevelToLoad { get; private set; }
        public SaveData() {
            LevelToLoad = LevelTracker.LevelToLoad;
        }
    }
}