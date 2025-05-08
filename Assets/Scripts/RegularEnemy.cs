using UnityEngine;

public class RegularEnemy : MonoBehaviour
{

     public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<Health>().DoDamage(GetComponent<EnemyValues>().damage);
            GameManager.Instance.enemycount--;
            Destroy(gameObject);
        }
    }
}
