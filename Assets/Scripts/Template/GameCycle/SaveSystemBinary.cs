using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

namespace Template.GameCycle {

    public class SaveSystemBinary: ISaveSystem {
        static string _path = Application.persistentDataPath + "/saveddata.sd";
        
        public void SaveGame() {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(_path, FileMode.OpenOrCreate);

            SaveData savedData = new SaveData();

            formatter.Serialize(stream, savedData);
            stream.Close();
        }

        public SaveData LoadGame() {
            if (File.Exists(_path)) {
                BinaryFormatter formatter = new BinaryFormatter();

                FileStream stream = new FileStream(_path, FileMode.Open);

                SaveData savedData;
                if (stream.Length == 0) {
                    savedData = new SaveData();
                }
                else {
                    savedData = formatter.Deserialize(stream) as SaveData;
                }

                stream.Close();
                return savedData;
            }
            else {
                SaveGame();
                return LoadGame();
            }
        }

        public void ClearData() {
            Debug.Log("Deleting saveddata");
            File.Delete(_path);
        }
    }
}
