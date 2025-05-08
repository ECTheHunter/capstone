using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System;
using System.IO;
using System.Collections.Generic;

[Serializable]
public class SaveData
{
    public string username;
    public int score;
    public int level;
}
[Serializable]
public class Highscores
{
    public List<SaveData> entries = new List<SaveData>();
}
public class GameOverPanel : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI levelText;
    public TMP_InputField nameInputField;
    private GameManager gameManager;
    private string filePath;
    private void Awake()
    {
        filePath = Path.Combine(Application.persistentDataPath, "highscores.json");
    }
    private void Start()
    {

        gameManager = GameManager.Instance;
    }

    private void Update()
    {
        if (gameManager != null)
        {
            scoreText.text = "Max Score: " + gameManager.playerscore;
            levelText.text = "Max Level: " + gameManager.level;
        }
    }
    public void SaveData()
    {
        SaveData newEntry = new SaveData
        {
            username = nameInputField.text,
            score = gameManager.playerscore,
            level = gameManager.level,
        };

        Highscores dataList = new Highscores();

        // Load existing data if file exists
        if (File.Exists(filePath))
        {
            string existingJson = File.ReadAllText(filePath);
            dataList = JsonUtility.FromJson<Highscores>(existingJson);

            if (dataList == null || dataList.entries == null)
            {
                dataList = new Highscores(); // fallback in case of bad JSON
            }
        }

        // Add new entry
        dataList.entries.Add(newEntry);

        // Save back to file
        string newJson = JsonUtility.ToJson(dataList, true);
        File.WriteAllText(filePath, newJson);

        Debug.Log($"Data appended and saved to {filePath}\n{newJson}");
    }

}
