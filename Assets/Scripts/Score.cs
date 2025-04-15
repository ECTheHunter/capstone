using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;

    private void Update()
    {
        if (scoreText != null)
        {
            scoreText.text = $"{GameManager.Instance.playerscore}";
        }
        else
        {
            Debug.LogWarning("ScoreText is not assigned in the Inspector!");
        }
    }
}