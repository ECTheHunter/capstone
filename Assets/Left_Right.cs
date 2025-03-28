using UnityEngine;

public class Left_Right : MonoBehaviour
{
    [SerializeField] private bool directionleft;
    [SerializeField] private float speed;
    [SerializeField] private float shootrate;
    [SerializeField] private GameObject projectile;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

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
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Border")
        {
            directionleft = !directionleft;
        }
    }
}
