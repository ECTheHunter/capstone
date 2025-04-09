using UnityEngine;
using Pathfinding;

public class EnemyAI : MonoBehaviour
{
    private Path path;
    [SerializeField] private float movespeed;
    [SerializeField] private Transform target;
    [SerializeField] private float nextpointdistance;
    private int currentwaypoint = 0;
    public bool reachedpath = false;
    private Seeker seeker;
    private Rigidbody2D rb2D;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        seeker = GetComponent<Seeker>();
        rb2D = GetComponent<Rigidbody2D>();
        InvokeRepeating("UpdatePath", 0f, 0.5f);
        Physics2D.IgnoreLayerCollision(7, 6);
        Physics2D.IgnoreLayerCollision(7, 7);
        target = GameManager.Instance.player.transform;

    }
    private void UpdatePath()
    {
        if (seeker.IsDone()) { seeker.StartPath(rb2D.position, target.position, OnPathComplete); }
    }
    private void OnPathComplete(Path p)
    {
        if (!p.error)
        {
            path = p;
            currentwaypoint = 0;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (path == null)
        {
            return;
        }
        if (currentwaypoint >= path.vectorPath.Count)
        {
            reachedpath = true;
            return;
        }
        else
        {
            reachedpath = false;
        }
        Vector2 direction = ((Vector2)path.vectorPath[currentwaypoint] - rb2D.position).normalized;
        Vector2 force = direction * movespeed * Time.deltaTime;
        rb2D.AddForce(force);
        float distance = Vector2.Distance(rb2D.position, path.vectorPath[currentwaypoint]);
        if (distance < nextpointdistance)
        {
            currentwaypoint++;
        }

    }
    void Update()
    {
        
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<Health>().DoDamage(GetComponent<EnemyValues>().damage);
            Destroy(gameObject);
        }
    }
 
}
