using TMPro;
using UnityEngine;

public class ListItem : MonoBehaviour
{
    public TextMeshProUGUI username;
    public TextMeshProUGUI score;
    public TextMeshProUGUI level;
    public string usernamevalue;
    public int scorevalue;
    public int levelvalue;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        username.text = usernamevalue;
        score.text = scorevalue.ToString();
        level.text = levelvalue.ToString();
    }
}
