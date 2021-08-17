using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    public static DataManager Instance;
    public string CurrentPlayerName;
    public string MaxPlayerName;
    public int MaxScore;

    private void Awake()
    {
        if(Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        LoadScore();
    }

    public void SaveScore()
    {
        SaveData data = new SaveData();
        data.MaxPlayerName = MaxPlayerName;
        data.MaxScore = MaxScore;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadScore()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            MaxPlayerName = data.MaxPlayerName;
            MaxScore = data.MaxScore;
        }
        else
        {
            MaxPlayerName = "";
            MaxScore = 0;
        }
    }
}

[System.Serializable]
public class SaveData
{
    public string MaxPlayerName;
    public int MaxScore;
}
