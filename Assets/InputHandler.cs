using System;
using UnityEngine;
public class InputHandler : MonoBehaviour
{
    private float pistoltimestamp;
    private float machineguntimestamp;
    private float shotguntimestamp;
    private float blackholetimestamp;
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
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            GameManager.Instance.weaponmode = (int)GameManager.WEAPONMODE.BlackHolemode;
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
                        hit.collider.gameObject.GetComponent<EnemyValues>().EatDamage(GameManager.Instance.pistoldamage);
                    }
                }
            }
            if (GameManager.Instance.weaponmode == (int)GameManager.WEAPONMODE.BlackHolemode)
            {
                if (Time.time > blackholetimestamp)
                {
                    SoundManager.Instance.PlaySound(SoundManager.Instance.pistolFiredClip);
                    blackholetimestamp = Time.time + GameManager.Instance.blackholefirerate;
                    Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                    Instantiate(GameManager.Instance.blackholeinstance, mousePosition, Quaternion.identity);
                }
            }
            if (GameManager.Instance.weaponmode == (int)GameManager.WEAPONMODE.Shotgunmode)
            {
                if (Time.time > shotguntimestamp)
                {
                    SoundManager.Instance.PlaySound(SoundManager.Instance.shotgunFiredClip);
                    shotguntimestamp = Time.time + GameManager.Instance.shotgunfirerate;

                    int pelletCount = GameManager.Instance.shotgunpellets; // Number of pellets per shot
                    float spreadDistance = GameManager.Instance.shotgunspread; // Spread distance for randomness
                    LayerMask enemyLayer = LayerMask.GetMask("Enemy");

                    for (int i = 0; i < pelletCount; i++)
                    {
                        Vector2 randomOffset = new Vector2(UnityEngine.Random.Range(-spreadDistance, spreadDistance), UnityEngine.Random.Range(-spreadDistance, spreadDistance));
                        Vector2 shootPosition = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition) + randomOffset;
                        Debug.DrawLine(shootPosition, shootPosition + Vector2.right * 0.1f, Color.red, 0.5f);
                        RaycastHit2D hit = Physics2D.Raycast(shootPosition, Vector2.zero, Mathf.Infinity, enemyLayer);
                        if (hit.collider != null && hit.collider.gameObject.tag == "Enemy")
                        {
                            hit.collider.gameObject.GetComponent<EnemyValues>().EatDamage(GameManager.Instance.shotgundamage);
                        }
                    }
                }

            }
        }
        if (Input.GetMouseButton(0))
        {
            if (GameManager.Instance.weaponmode == (int)GameManager.WEAPONMODE.Machinegunmode)
            {
                if (Time.time > machineguntimestamp)
                {
                    SoundManager.Instance.PlaySound(SoundManager.Instance.machinegunFiredClip);
                    machineguntimestamp = Time.time + GameManager.Instance.machinegunfirerate;
                    LayerMask enemyLayer = LayerMask.GetMask("Enemy");
                    RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero, Mathf.Infinity, enemyLayer);
                    if (hit.collider.gameObject.tag == "Enemy")
                    {
                        hit.collider.gameObject.GetComponent<EnemyValues>().EatDamage(GameManager.Instance.machinegundamage);
                    }
                }
            }
        }
    }
}
