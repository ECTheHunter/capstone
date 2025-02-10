using UnityEngine;
using Pathfinding;

public class EnemyAI : MonoBehaviour
{
    private AIPath path;
    [SerializeField] private float movespeed;
    [SerializeField] private Transform target;
    [SerializeField] public float health;
    [SerializeField] public float damage;
    private int currentwaypoint = 0;
    private bool reachedpath = false;
    private Seeker seeker;
    private Rigidbody2D rb2D;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        path = GetComponent<AIPath>();
        seeker = GetComponent<Seeker>();
        rb2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        path.maxSpeed = movespeed;
        path.destination = target.position;
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("sds");
        if(collision.gameObject.tag == "Player"){
            
            collision.gameObject.GetComponent<Health>().DoDamage(damage);
        }
    }
}
