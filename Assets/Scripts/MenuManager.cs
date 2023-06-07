using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class MenuManager : MonoBehaviour
{
    
    public static MenuManager Instance;

    public int highScore;
    public string playerName;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);

        LoadHighScore();
    }

    [System.Serializable]
    class SaveData
    {
        public int highScore;
        public string playerName;
    }

    public void SaveHighScore()
    {
        if(MainManager.newScore> highScore)
        {
            SaveData data = new SaveData();
            data.highScore = MainManager.newScore;
            data.playerName = MenuUIHandle.newplayerName;

            string json = JsonUtility.ToJson(data);
            Debug.Log(Application.persistentDataPath);
            File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
        }
       
    }

    public void LoadHighScore()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            highScore = data.highScore;
            playerName = data.playerName;
        }
    }
    private void Update()
    {
        Debug.Log(MenuManager.Instance.playerName);
    }
}




