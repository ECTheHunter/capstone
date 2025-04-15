using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    [SerializeField] public Image healthBarFill;
    [SerializeField] public Gradient colorGradient;

    [SerializeField] public TextMeshProUGUI healthText;

    void Update()
    {
        UpdateHealthBar();
    }

    public void DoDamage(float damage)
    {
        GameManager.Instance.healthvalue -= damage;

        if (GameManager.Instance.healthvalue == 0)
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
        Debug.Log("Player has died.");
    }
}