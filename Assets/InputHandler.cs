using System;
using UnityEngine;
public class InputHandler : MonoBehaviour
{
    private float pistoltimestamp;
    private float machineguntimestamp;
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
         if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            GameManager.Instance.weaponmode = (int)GameManager.WEAPONMODE.Shotgunmode;
        }


        if (Input.GetMouseButtonDown(0))
        {
            if (GameManager.Instance.weaponmode == (int)GameManager.WEAPONMODE.Pistolmode)
            {
                if (Time.time > pistoltimestamp)
                {
                    SoundManager.Instance.PlaySound(SoundManager.Instance.pistolFiredClip);
                    pistoltimestamp = Time.time + GameManager.Instance.pistolfirerate;
                    LayerMask enemyLayer = LayerMask.GetMask("Enemy");
                    RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero, Mathf.Infinity, enemyLayer);
                    if (hit.collider.gameObject.tag == "Enemy")
                    {
                        hit.collider.gameObject.GetComponent<EnemyValues>().EatDamage(GameManager.Instance.damage);
                    }
                }
            }
            if(GameManager.Instance.weaponmode == (int)GameManager.WEAPONMODE.Shotgunmode)
            {
                SoundManager.Instance.PlaySound(SoundManager.Instance.pistolFiredClip);
                LayerMask enemyLayer = LayerMask.GetMask("Enemy");
            }

        }
        
        if (Input.GetMouseButton(0))
        {
            if (GameManager.Instance.weaponmode == (int)GameManager.WEAPONMODE.Machinegunmode)
            {
                if (Time.time > machineguntimestamp)
                {
                    SoundManager.Instance.PlaySound(SoundManager.Instance.pistolFiredClip);
                    machineguntimestamp = Time.time + GameManager.Instance.machinegunfirerate;
                    LayerMask enemyLayer = LayerMask.GetMask("Enemy");
                    RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero, Mathf.Infinity, enemyLayer);
                    if (hit.collider.gameObject.tag == "Enemy")
                    {
                        hit.collider.gameObject.GetComponent<EnemyValues>().EatDamage(GameManager.Instance.damage);
                    }
                }
            }
        }
    }
}
