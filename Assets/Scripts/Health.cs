using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    [SerializeField] public Image healthBarFill;
    [SerializeField] public Gradient colorGradient;
    [SerializeField] public TextMeshProUGUI healthText;

    [SerializeField] private GameObject gameOverPanel;
    private bool isDead = false;

    private void Start()
    {
        if (gameOverPanel == null)
        {
            Debug.LogError("GameOverPanel bulunamadı! Sahneye ekli mi?");
        }
    }

    void Update()
    {
        UpdateHealthBar();
    }

    public void DoDamage(float damage)
    {
        GameManager.Instance.healthvalue -= damage;
        GameManager.Instance.healthvalue = Mathf.Clamp(GameManager.Instance.healthvalue, 0, 100);

        if (GameManager.Instance.healthvalue <= 0)
        {
            Die();
        }
    }

    public void UpdateHealthBar()
    {
        if (healthBarFill != null)
        {
            healthBarFill.fillAmount = GameManager.Instance.healthvalue / 100f;
            healthBarFill.color = colorGradient.Evaluate(healthBarFill.fillAmount);
            healthText.text = $"{GameManager.Instance.healthvalue:0}";
        }
        else
        {
            Debug.LogWarning("Health bar fill is not assigned in the Inspector!");
        }
    }
    public void Die()
    {
        if (isDead) return; // Eğer zaten öldüyse, tekrar çalıştırma
        isDead = true;

        Debug.Log("Player has died.");

        if (gameOverPanel != null)
        {
             Time.timeScale = 0f; 
            gameOverPanel.gameObject.SetActive(true);
        }
    }
}