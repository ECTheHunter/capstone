using Unity.Collections;
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
    public void RandomPickUp()
    {
        int randomValue = Random.Range(1, 101); // 0, 1, or 2
Debug.Log("GameManager instance is afddsfdsdfffffffffffffffffff. Cannot spawn pickup.");
        GameObject prefabToSpawn = null;
        if (GameManager.Instance == null)
        {
            Debug.Log("GameManager instance is null. Cannot spawn pickup.");
            return;
        }
        if (randomValue > 1 && randomValue < 40)
        {
            prefabToSpawn = null;
        }
        else if (randomValue > 40 && randomValue < 65)
        {
            prefabToSpawn = GameManager.Instance.healthpickup;
        }
        else if (randomValue > 65 && randomValue < 90)
        {
            prefabToSpawn = GameManager.Instance.ammopickup;
        }
        else if (randomValue > 90 && randomValue < 101)
        {
            prefabToSpawn = GameManager.Instance.doubledamage;

        }
        if (prefabToSpawn != null)
        {
            Instantiate(prefabToSpawn, transform.position, Quaternion.identity);
        }
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
        RandomPickUp();
        Destroy(gameObject);
    }
}
