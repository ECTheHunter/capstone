using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameOverPanel : MonoBehaviour
{
    public GameObject gameOverPanel;
    public GameObject highScoresPanel;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI levelText;
    public TMP_InputField nameInputField;

    private GameManager gameManager;

    private void Start()
    {
        gameOverPanel.SetActive(false);
        highScoresPanel.SetActive(false);

        gameManager = GameManager.Instance;
    }

    private void Update()
    {
        if (gameManager != null)
        {
            Debug.Log($"Health Value: {gameManager.healthvalue}");
            if (gameManager.healthvalue <= 0)
            {
                
            }
        }
    }

}