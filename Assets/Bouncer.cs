using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Bouncer : MonoBehaviour
{
    [SerializeField] private bool enteredscene = false;
    [SerializeField] private float damage;
    [SerializeField] private float movespeed;
    [SerializeField] private float health;
    private Rigidbody2D rb2D;
    [SerializeField] private float splitfactor;
    private Vector2 direction;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        direction = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized;
        Physics2D.IgnoreLayerCollision(0, 6);
        rb2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector2 force = direction * movespeed * Time.deltaTime;
        rb2D.AddForce(force);
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Border")
        {
            if (!enteredscene)
            {
                enteredscene = true;
                return;
            }
            else if (enteredscene)
            {
                var firstcontact = collision.ClosestPoint(transform.position);
                var collisionNormal = ((Vector2)transform.position - firstcontact).normalized;
                Vector2 newVelocity = Vector2.Reflect(rb2D.linearVelocity.normalized, collisionNormal);
                direction = newVelocity;

            }
        }

    }
}
