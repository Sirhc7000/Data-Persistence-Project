using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class StartMenuData : MonoBehaviour
{
    public void LoadHighScore()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            PlayerData.Instance.playerName = data.highScorePlayer;
            PlayerData.Instance.score = data.highScore;

        }
    }

    [System.Serializable]
    class SaveData
    {
        public int highScore;
        public string highScorePlayer;
    }
}
