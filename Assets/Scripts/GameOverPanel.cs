using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameOverPanel : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI levelText;
    public TMP_InputField nameInputField;
    private GameManager gameManager;

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

}