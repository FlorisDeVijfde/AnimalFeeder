using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class PersistanceManager : MonoBehaviour
{
    public static PersistanceManager Instance;

    public string playerName;
    public string topScorerName;
    public int topScore;

    private string path;

    [System.Serializable]
    class SaveData
    {
        public string savedPlayerName;
        public int savedTopScore;
    }

    void Awake()
    {
        //Singleton
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);

        //Filepath. Has to be set here, not in class constructor 
        path = Application.persistentDataPath + "/SaveData.json";
    }

    public void SaveTopScore(int topScore)
    {
        //Prepare class for json conversion
        SaveData saveData = new SaveData();
        saveData.savedPlayerName = Instance.playerName;
        saveData.savedTopScore = topScore;

        //Convert to json readable string
        string json = JsonUtility.ToJson(saveData);
        //Write to file
        File.WriteAllText(path, json);
    }

    public void LoadTopScore()
    {
        if (File.Exists(path))
        { 
            string json = File.ReadAllText(path);

            SaveData saveData = new SaveData();
            saveData = JsonUtility.FromJson<SaveData>(json);

            topScorerName = saveData.savedPlayerName;
            topScore = saveData.savedTopScore;
        }
        else
        {
            topScorerName = "Nobody";
            topScore = 0;
        }
    }
}
