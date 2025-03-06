using UnityEngine;

public class Health : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GameManager.Instance.player = this.gameObject;
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void DoDamage(float damage)
    {
        GameManager.Instance.healthvalue -= damage;
        SoundManager.Instance.PlayBaseTakeDamageSound();
    }
}
