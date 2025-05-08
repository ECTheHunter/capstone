using System.Collections;
using UnityEngine;

public class Bouncer : MonoBehaviour
{
    [SerializeField] private bool enteredscene = false;
    [SerializeField] private float movespeed;
    private Rigidbody2D rb2D;
    [SerializeField] private float splitfactor;
    private Vector2 direction;
    [SerializeField] private GameObject bouncerPrefab;
    [SerializeField] private Transform spawnpoint1;
    [SerializeField] private bool isminion;
    [SerializeField] private float minumumscale;
    public bool isvertical;
    public bool directionleft;
    private float spawnTime;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spawnTime = Time.time;
        if (!isminion)
        {
            float angleOffset = Random.Range(-30f, 30f); // Random offset within -45 to 45 degrees
            if (isvertical)
            {
                if (!directionleft)
                {
                    direction = Quaternion.Euler(0, 0, angleOffset) * transform.up * -1; // Use transform.right as the base direction
                    direction = direction.normalized;
                }
                else
                {
                    direction = Quaternion.Euler(0, 0, angleOffset) * transform.up; // Use transform.right as the base direction
                    direction = direction.normalized;
                }
            }
            else
            {
                if (directionleft)
                {
                    direction = Quaternion.Euler(0, 0, angleOffset) * transform.right * -1; // Use transform.right as the base direction
                    direction = direction.normalized;
                }
                else
                {
                    direction = Quaternion.Euler(0, 0, angleOffset) * transform.right; // Use transform.right as the base direction
                    direction = direction.normalized;
                }
            }

        }

        Physics2D.IgnoreLayerCollision(7, 6);
        Physics2D.IgnoreLayerCollision(7, 7);
        rb2D = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle + 90f, Vector3.forward);

    }
    // Update is called once per frame
    void FixedUpdate()
    {
        Vector2 force = direction * movespeed * Time.deltaTime;

        rb2D.AddForce(force);
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Corner")
        {
            Vector2 toCenter = (new Vector2(500f, 250f) - rb2D.position).normalized;
            direction = toCenter;
            return;

        }
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
                Vector2 newVelocity = Vector2.Reflect(rb2D.linearVelocity.normalized, collisionNormal).normalized;
                direction = newVelocity;
                if (transform.localScale.magnitude > new Vector3(minumumscale, minumumscale, minumumscale).magnitude && Time.time - spawnTime >= 1f)
                    StartCoroutine(BounceOperation());
            }
        }

    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<Health>().DoDamage(GetComponent<EnemyValues>().damage);
            Destroy(gameObject);
        }
    }
    IEnumerator BounceOperation()
    {

        GameObject newBouncer1 = Instantiate(bouncerPrefab, (Vector2)spawnpoint1.position, Quaternion.identity);
        GameObject newBouncer2 = Instantiate(bouncerPrefab, (Vector2)spawnpoint1.position, Quaternion.identity);
        Bouncer bouncerScript1 = newBouncer1.GetComponent<Bouncer>();
        Bouncer bouncerScript2 = newBouncer2.GetComponent<Bouncer>();
        EnemyValues enemyValues1 = newBouncer1.GetComponent<EnemyValues>();
        EnemyValues enemyValues2 = newBouncer2.GetComponent<EnemyValues>();


        newBouncer1.transform.localScale = transform.localScale * splitfactor;
        newBouncer2.transform.localScale = transform.localScale * splitfactor;
        bouncerScript1.movespeed = movespeed * (1 + (1 - splitfactor));
        bouncerScript2.movespeed = movespeed * (1 + (1 - splitfactor));
        enemyValues1.health = GetComponent<EnemyValues>().health * splitfactor;
        enemyValues2.health = GetComponent<EnemyValues>().health * splitfactor;
        enemyValues1.damage = GetComponent<EnemyValues>().damage * splitfactor;
        enemyValues2.damage = GetComponent<EnemyValues>().damage * splitfactor;

        // Set the direction of the new bouncers within -45 to 45 degrees
        float angleOffset1 = Random.Range(10f, 45f);
        float angleOffset2;

        do
        {
            angleOffset2 = Random.Range(-10f, 30f);
        } while (Mathf.Abs(angleOffset2 - angleOffset1) < 15f);

        float baseAngle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        float angle1 = baseAngle + angleOffset1;
        float angle2 = baseAngle + angleOffset2;

        bouncerScript1.isminion = true;
        bouncerScript2.isminion = true;
        bouncerScript1.SetDirection(new Vector2(Mathf.Cos(angle1 * Mathf.Deg2Rad), Mathf.Sin(angle1 * Mathf.Deg2Rad)).normalized);
        bouncerScript2.SetDirection(new Vector2(Mathf.Cos(angle2 * Mathf.Deg2Rad), Mathf.Sin(angle2 * Mathf.Deg2Rad)).normalized);


        Destroy(gameObject);
        yield return null;
    }

    public void SetDirection(Vector2 newDirection)
    {
        direction = newDirection;
    }
}
