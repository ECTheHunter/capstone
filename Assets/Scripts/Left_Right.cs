using UnityEngine;

public class Left_Right : MonoBehaviour
{
    public bool directionleft;
    [SerializeField] private float speed;
    [SerializeField] private float shootrate;
    [SerializeField] private GameObject projectile;
    [SerializeField] private Animator animator;
    public bool l_r;
    [SerializeField] private bool inscene;
    private float nextShootTime;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        nextShootTime = shootrate;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 dir = Vector3.zero;
        if (l_r)
        {
            if (directionleft)
            {
                dir = transform.right * -1 * speed * Time.deltaTime;
            }
            else
            {
                dir = transform.right * speed * Time.deltaTime;
            }
            transform.Translate(dir);
        }
        else
        {
            if (!directionleft)
            {
                dir = transform.up * speed * Time.deltaTime;
            }
            else
            {
                dir = transform.up * -1 * speed * Time.deltaTime;
            }
            transform.Translate(dir);
        }
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
            if (!inscene)
            {
                inscene = true;
                return;
            }
            directionleft = !directionleft;
        }
    }
}
