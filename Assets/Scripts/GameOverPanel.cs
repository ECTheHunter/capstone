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
                ShowGameOverPanel(gameManager.playerscore, gameManager.level);
            }
        }
    }

    public void ShowGameOverPanel(int score, int level)
    {
        Debug.Log("Game Over Panel Açılıyor...");
        Time.timeScale = 0f; // Oyunu durdur
        gameOverPanel.SetActive(true);
        scoreText.text = $"Score: {score}";
        levelText.text = $"Level: {level}";
    }

    public void ShowHighScores()
    {
        gameOverPanel.SetActive(false);
        highScoresPanel.SetActive(true);
        // High Scores panel logic can be added here
    }

    public void BackToGameOver()
    {
        highScoresPanel.SetActive(false);
        gameOverPanel.SetActive(true);
    }

    public void RestartGame()
    {
        Time.timeScale = 1f; 
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}