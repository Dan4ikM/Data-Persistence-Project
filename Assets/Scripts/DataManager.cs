using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class DataManager : MonoBehaviour
{
    public static DataManager Instance;

    private void Awake()
    {
        if(Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
        
        CurrentScore = new Score();
        BestScore = new Score();
        LoadBestScore();
    }

    public Score CurrentScore;
    public Score BestScore;

    [System.Serializable]
    class SaveData
    {
        public int Score;
        public string PlayerName;
    }

    public bool IsUpdateBestScore(int points)
    {
        CurrentScore.Points = points;
        if(BestScore.Points < points)
        {
            BestScore = CurrentScore;
            SaveBestScore();
            return true;
        }
        return false;
    }

    public void SaveBestScore()
    {
        SaveData data = new SaveData();

        data.Score = CurrentScore.Points;
        data.PlayerName = CurrentScore.PlayerName;

    string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
        Debug.Log(Application.persistentDataPath);
    }

    public void LoadBestScore()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        Debug.Log(Application.persistentDataPath);
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);
            
            BestScore.PlayerName = data.PlayerName;
            BestScore.Points = data.Score;
        }
        else
        {
            Debug.LogAssertion("Can't find savefile");
        }
    }
}
