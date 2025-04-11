using UnityEngine;

public class Left_Right : MonoBehaviour
{
    [SerializeField] private bool directionleft;
    [SerializeField] private float speed;
    [SerializeField] private float shootrate;
    [SerializeField] private GameObject projectile;
    [SerializeField] private Animator animator;
    private float nextShootTime;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = GetComponent<Animator>();
        nextShootTime = shootrate;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 dir = Vector3.zero;
        if (directionleft)
        {
            dir = Vector2.left * speed * Time.deltaTime;
        }
        else
        {
            dir = Vector2.right * speed * Time.deltaTime;
        }
        transform.Translate(dir);
        if (Time.time >= nextShootTime)
        {
            animator.SetTrigger("Shoot");
            nextShootTime = Time.time + shootrate;  // Set the next shoot time
        }
    }
    public void Shoot()
    {
        GameObject bullet = Instantiate(projectile, transform.position, transform.rotation);
        bullet.GetComponent<L_R_Bullet>().damage = GetComponent<EnemyValues>().damage;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Border")
        {
            directionleft = !directionleft;
        }
    }
}
