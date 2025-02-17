using System.Collections;
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
    [SerializeField] private bool cansplit = false;
    [SerializeField] private GameObject bouncerPrefab;
    [SerializeField] private Transform spawnpoint1;
    [SerializeField] private Transform spawnpoint2;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        direction = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized;
        Physics2D.IgnoreLayerCollision(7, 6);
        Physics2D.IgnoreLayerCollision(7, 7);
        rb2D = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, 1f);
        Debug.DrawRay(transform.position, direction);
        if (hit.collider == null)
        {
            cansplit = false;
        }
        if (hit.collider.tag == "Border")
        {
            cansplit = true;
        }
        else
        {
            cansplit = false;
        }

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
                if (!cansplit)
                {
                    return;
                }
                else if (cansplit)
                {
                    var firstcontact = collision.ClosestPoint(transform.position);
                    var collisionNormal = ((Vector2)transform.position - firstcontact).normalized;
                    Vector2 newVelocity = Vector2.Reflect(rb2D.linearVelocity.normalized, collisionNormal).normalized;
                    direction = newVelocity;
                    float angle = Mathf.Atan2(rb2D.linearVelocityY, rb2D.linearVelocityX) * Mathf.Rad2Deg;
                    transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
                    StartCoroutine(BounceOperation(newVelocity));
                }


            }
        }

    }
    IEnumerator BounceOperation(Vector2 newVelocity)
    {

        while (cansplit)
        {
            yield return null;
        }
        GameObject newBouncer1 = Instantiate(bouncerPrefab, (Vector2)spawnpoint1.position, Quaternion.identity);
        GameObject newBouncer2 = Instantiate(bouncerPrefab, (Vector2)spawnpoint2.position, Quaternion.identity);

        Bouncer bouncerScript1 = newBouncer1.GetComponent<Bouncer>();
        Bouncer bouncerScript2 = newBouncer2.GetComponent<Bouncer>();
        bouncerScript1.SetDirection(newVelocity + new Vector2(Random.Range(-0.2f, 0.2f), Random.Range(-0.2f, 0.2f)));
        bouncerScript2.SetDirection(newVelocity + new Vector2(Random.Range(-0.2f, 0.2f), Random.Range(-0.2f, 0.2f)));

        Destroy(gameObject);
        yield return null;
    }

    public void SetDirection(Vector2 newDirection)
    {
        direction = newDirection;
    }
}
