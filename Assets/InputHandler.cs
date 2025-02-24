using UnityEngine;
using UnityEngine.InputSystem;
public class InputHandler : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void OnClick(InputAction.CallbackContext context)
    {
        if (!context.started)
        {
            return;
        }
        Collider2D hit = Physics2D.OverlapPoint(Camera.main.ScreenToWorldPoint(Input.mousePosition));
        if (hit != null && hit.CompareTag("Enemy"))
        {
            hit.GetComponent<EnemyAI>().EatDamage(GameManager.Instance.damage);
        }
    }
}
