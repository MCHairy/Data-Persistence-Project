using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class MenuManager : MonoBehaviour
{
    public static MenuManager Instance;
    private static string playerName;
    private SortedList<int, string> topScores;
    private int topScore;
    private string topPlayerName;

    private void Awake()
    {
        if(Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
        topScores = new SortedList<int, string>();
        LoadData();
    }

    public void SetPlayerName(string nameUpdate)
    {
        playerName = nameUpdate;
    }

    public string GetPlayerName()
    {
        return playerName;
    }

    public void AddTopScore(string name, int score)
    {
        topScores.Add(score, name);
    }

    public int GetTopScore()
    {
        if (topScores.Count != 0)
        {
            return topScores.Keys[topScores.Count - 1];
        } else
        {
            return 0;
        }

    }

    public string GetTopPlayer()
    {
        if (topScores.Count != 0)
        {
            return topScores.Values[0];
        } else
        {
            return "";
        }
    }

    public void StartSaveData()
    {
        SaveData data = new SaveData();
        data.topScores = topScores;


        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadData()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);
            topScores = data.topScores;
        }
    }



    [System.Serializable]
    class SaveData
    {
        public SortedList<int, string> topScores;
    }

}
