using UnityEngine;

public class BlackHole : MonoBehaviour
{
    [SerializeField] private float force;
    [SerializeField] private float duration;
    [SerializeField] private float rotationspeed;
    private float spawnTime;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spawnTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > spawnTime + duration)
        {
            Destroy(gameObject);
        }
        transform.Rotate(new Vector3(0f, 0f, -rotationspeed) * Time.deltaTime);
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            Rigidbody2D rb = other.attachedRigidbody;

            if (rb == null) return;
            Vector2 center = transform.position;
            float magnitude = ((Vector2)other.transform.position - center).magnitude;
            Vector2 direction = ((Vector2)other.transform.position - center).normalized * -1 / magnitude;
            if (direction.magnitude == 0) return;
            rb.AddForce(direction * force, ForceMode2D.Force);

        }

    }
}
