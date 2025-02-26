using System;
using UnityEngine;
public class InputHandler : MonoBehaviour
{
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            GameManager.Instance.weaponmode = (int)GameManager.WEAPONMODE.Pistolmode;
        }
         if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            GameManager.Instance.weaponmode = (int)GameManager.WEAPONMODE.Machinegunmode;
        }


        if (Input.GetMouseButtonDown(0))
        {
            if (GameManager.Instance.weaponmode == (int)GameManager.WEAPONMODE.Pistolmode)
            {
                LayerMask enemyLayer = LayerMask.GetMask("Enemy");
                RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero, Mathf.Infinity, enemyLayer);
                if (hit.collider.gameObject.tag == "Enemy")
                {
                    hit.collider.gameObject.GetComponent<EnemyValues>().EatDamage(GameManager.Instance.damage);
                }
            }

        }
        if (Input.GetMouseButton(0))
        {
            if (GameManager.Instance.weaponmode == (int)GameManager.WEAPONMODE.Machinegunmode)
            {
                print("hold");
            }
        }
    }
}
