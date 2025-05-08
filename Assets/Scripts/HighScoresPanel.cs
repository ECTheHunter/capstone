using System.IO;
using UnityEngine;

public class HighScoresPanel : MonoBehaviour
{
    public GameObject listItemPrefab;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    string filePath;
    public Transform contentParent;
    void Start()
    {
        filePath = Path.Combine(Application.persistentDataPath, "highscores.json");
        LoadAndPopulate();
    }

    void LoadAndPopulate()
    {


        if (File.Exists(filePath))
        {
            string json = File.ReadAllText(filePath);
            Highscores data = JsonUtility.FromJson<Highscores>(json);

            foreach (var item in data.entries)
            {
                GameObject newItem = Instantiate(listItemPrefab, contentParent);
                newItem.transform.localScale = Vector3.one;
                newItem.GetComponent<ListItem>().scorevalue = item.score;
                newItem.GetComponent<ListItem>().levelvalue = item.level;
                newItem.GetComponent<ListItem>().usernamevalue = item.username;
            }

        }

    }
}
