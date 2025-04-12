using System.Collections;
using Unity.Collections;
using UnityEngine;

public class EnemyValues : MonoBehaviour
{
    public enum EnemyTypes
    {
        regularenemy,
        bouncingenemy,
        left_right,
        chomper

    }
    public EnemyTypes enemyType;
    public float health;
    public float damage;
    public SpriteRenderer spriteRenderer;
    public Material originalMaterial;
    public Material flashMaterial;
    public Animator animator;
    public int enemyscore;
    void Awake()
    {
        originalMaterial = spriteRenderer.material;
    }

    private void Update()
    {
        if (health <= 0)
        {
            animator.SetTrigger("Die");
        }
    }
    public void EatDamage(float damage)
    {
        StartCoroutine(FlashRoutine());
        GetComponent<EnemyValues>().health -= damage;
    }
    private IEnumerator FlashRoutine()
    {

        for (int i = 0; i < 3; i++)
        {
            spriteRenderer.material = flashMaterial;
            yield return new WaitForSeconds(0.1f);
            spriteRenderer.material = originalMaterial;
            yield return new WaitForSeconds(0.1f);
        }
    }
    public void RandomPickUp()
    {
        int randomValue = Random.Range(1, 101); // 0, 1, or 2

        GameObject prefabToSpawn = null;

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
            case EnemyTypes.chomper:
                SoundManager.Instance.PlaySound(SoundManager.Instance.chomperDestroyedClip);
                break;
        }
        GameManager.Instance.playerscore += enemyscore;
        RandomPickUp();
        Destroy(gameObject);
    }
}
