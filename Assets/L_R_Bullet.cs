using UnityEngine;

public class L_R_Bullet : MonoBehaviour
{
    [SerializeField] private float speed;
    public float damage;
    private Rigidbody2D rb2D;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        rb2D = GetComponent<Rigidbody2D>();
        GameObject player = GameManager.Instance.player;
        Vector2 dir = (player.transform.position - transform.position).normalized;
        rb2D.AddForce(dir * speed);

    }

    // Update is called once per frame
    void Update()
    {

    }
}
