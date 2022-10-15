
namespace Utilities {
    public static class LevelTracker {
        public static int LevelToLoad { get; set; } = 1;

        public static int MaxLevels => 10;

        public static int AdCounter = 0;
        public static string Version => "0.1";
    }
}