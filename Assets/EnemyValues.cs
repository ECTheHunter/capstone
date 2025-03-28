using System;
using UnityEngine;

public class EnemyValues : MonoBehaviour
{
    public enum EnemyTypes
    {
        regularenemy,
        bouncingenemy,
        left_right

    }
    public EnemyTypes enemyType;
    public float health;
    public float damage;

    private void Update()
    {
        if (health <= 0)
        {
            DestroyEnemy();
        }
    }
    public void EatDamage(float damage)
    {
        GetComponent<EnemyValues>().health -= damage;
    }
    public void DestroyEnemy()
    {
        switch (enemyType)
        {
            case EnemyTypes.regularenemy:
                SoundManager.Instance.PlaySound(SoundManager.Instance.regularenemyDestroyedClip);
                break;
            case EnemyTypes.bouncingenemy:
                SoundManager.Instance.PlaySound(SoundManager.Instance.bouncingDestroyedClip);
                break;
            case EnemyTypes.left_right:
                SoundManager.Instance.PlaySound(SoundManager.Instance.l_rDestroyedClip);
                break;
        }

        Destroy(gameObject);
    }
}
