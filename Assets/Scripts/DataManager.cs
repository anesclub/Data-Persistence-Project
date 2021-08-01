using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using TMPro;

public class DataManager : MonoBehaviour
{
    public TMP_InputField TMPInputField;
    public TextMeshProUGUI topScoreText;
    public static DataManager Instance;
    public string currentPlayerName;
    public string bestPlayerName;
    public int topScore;

    void Start()
    {   
        LoadNameFromFile();
        LoadTopScoreFromFile();
        topScoreText.text = "Best score: "+topScore+ " point by " + bestPlayerName;

    }


    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        
        Instance = this;
        DontDestroyOnLoad(gameObject);
        
    }

    
    [System.Serializable] public class SaveData
    {
        public string PlayerName;
        public int HigherScore;
    }

    public void SaveDataInFile()
    {   
        SaveData data = new SaveData();
        
        data.PlayerName = TMPInputField.text;
        if(TMPInputField != null)
        {
            data.PlayerName = TMPInputField.text;
        }      

        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }        

    public string LoadNameFromFile()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            bestPlayerName = data.PlayerName;
            
        }
        return bestPlayerName;
        
    }

    public int LoadTopScoreFromFile()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            topScore = data.HigherScore;
        }
    return topScore;

        
    }

    

}