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

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        direction = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized;
        Physics2D.IgnoreLayerCollision(0, 6);
        rb2D = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, direction);
        if (hit.collider != null)
        {
            print(hit.collider.gameObject.name);
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
                    Vector2 newVelocity = (Vector2.Reflect(rb2D.linearVelocity.normalized, collisionNormal)).normalized;
                    StartCoroutine(BounceOperation(newVelocity));
                }


            }
        }

    }
    IEnumerator BounceOperation(Vector2 newVelocity)
    {
        Vector2 spawnOffset = new Vector2(Random.Range(-0.2f, 0.2f), Random.Range(-0.2f, 0.2f));
        GameObject newBouncer1 = Instantiate(bouncerPrefab, (Vector2)transform.position + spawnOffset, Quaternion.identity);
        GameObject newBouncer2 = Instantiate(bouncerPrefab, (Vector2)transform.position - spawnOffset, Quaternion.identity);

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
