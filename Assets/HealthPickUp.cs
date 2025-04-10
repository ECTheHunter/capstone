using UnityEngine;

public class HealthPickUp : PickUpClass
{
    [SerializeField] public float healthamount;

    public override void pickUpEffect()
    {
        GameManager.Instance.healthvalue += healthamount;
        Destroy(gameObject);
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        int randomValue = Random.Range(0, 3); 

        switch (randomValue)
        {
            case 0:
                healthamount = 5f;
                break;
            case 1:
                healthamount = 10f;
                break;
            case 2:
                healthamount = 15f;
                break;
            default:
                healthamount = 5f;
                break;
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
