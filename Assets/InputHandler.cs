using System;
using UnityEngine;
public class InputHandler : MonoBehaviour
{
    public int count;
    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            LayerMask enemyLayer = LayerMask.GetMask("Enemy");
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero, Mathf.Infinity, enemyLayer);
            print(hit.collider.gameObject.name);
            if (hit.collider.gameObject.tag == "Enemy")
            {
                hit.collider.gameObject.GetComponent<EnemyValues>().EatDamage(GameManager.Instance.damage);
            }
        }
    }
}
