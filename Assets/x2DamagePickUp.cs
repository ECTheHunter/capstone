using UnityEngine;

public class x2DamagePickUp : PickUpClass
{
    public override void pickUpEffect()
    {
        GameManager.Instance.ActivateDoubleDamage();
        Destroy(gameObject);
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
