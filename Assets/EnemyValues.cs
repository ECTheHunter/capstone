using UnityEngine;

public class EnemyValues : MonoBehaviour
{
    public float health;
    public float damage;
    public void EatDamage(float damage)
    {
        GetComponent<EnemyValues>().health -= damage;
    }
}
