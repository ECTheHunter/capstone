using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    [SerializeField] public Image healthBarFill;
    [SerializeField] public Gradient colorGradient;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log($"Collided with: {collision.gameObject.name}, Tag: {collision.tag}");

        // Eğer çarpışan nesne bir Enemy ise
        if (collision.CompareTag("Projectile"))
        {
            EnemyValues enemyValues = collision.GetComponent<EnemyValues>();
            if (enemyValues != null)
            {
                float damage = enemyValues.damage; // Enemy'nin damage değerini al
                DoDamage(damage);
            }
        }
    }

    public void DoDamage(float damage)
    {
        GameManager.Instance.healthvalue -= damage;
        GameManager.Instance.healthvalue = Mathf.Clamp(GameManager.Instance.healthvalue, 0, 100);

        if (GameManager.Instance.healthvalue == 0)
        {
            Die();
        }

        UpdateHealthBar();
    }

    public void UpdateHealthBar()
    {
        if (healthBarFill != null)
        {
            healthBarFill.fillAmount = GameManager.Instance.healthvalue / 100f;
            healthBarFill.color = colorGradient.Evaluate(healthBarFill.fillAmount);
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