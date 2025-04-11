using System.Collections;
using UnityEngine;

public class Chomper : MonoBehaviour
{
    public Animator animator;
    void Awake()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision2D)
    {
        if (collision2D.gameObject.tag == "Player") // or enemy, etc.
        {
            StartCoroutine(ApplyDamageOverTime(collision2D.gameObject.GetComponent<Health>()));
        }
    }

    private void OnCollisonExit2D(Collision2D collision2D)
    {
        if (collision2D.gameObject.tag == "Player")
        {
            StopAllCoroutines(); // Stops damage when exiting
        }
    }

    private IEnumerator ApplyDamageOverTime(Health targetHealth)
    {
        while (targetHealth != null)
        {
            animator.SetTrigger("Attack");
            targetHealth.DoDamage(GetComponent<EnemyValues>().damage);
            yield return new WaitForSeconds(1f); // 1 second interval
        }
    }
}
