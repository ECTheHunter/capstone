using System;
using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public enum WEAPONMODE
    {
        Pistolmode,
        Machinegunmode,
        Shotgunmode,
        BlackHolemode
    }
    public static GameManager Instance { get; private set; }
    public float healthvalue;
    public GameObject player;
    public float pistoldamage;
    public float machinegundamage;
    public float shotgundamage;
    public int weaponmode = 0;
    public float machinegunfirerate;
    public float pistolfirerate;
    public float shotgunfirerate;
    public float blackholefirerate;
    public int shotgunpellets;
    public float shotgunspread;
    public GameObject blackholeinstance;
    public GameObject healthpickup;
    public GameObject ammopickup;
    public GameObject doubledamage;
    public int shotgunammo = 0;
    public int machinegunammo = 0;
    public int blackholeammo = 0;
    public bool doubledamagemodifier;
    public float doubleDamageDuration;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
        DontDestroyOnLoad(this);

    }
    public void ActivateDoubleDamage()
    {
        doubledamagemodifier = true;
        StartCoroutine(ResetDoubleDamageAfterTime(doubleDamageDuration));
    }
    private IEnumerator ResetDoubleDamageAfterTime(float duration)
    {
        yield return new WaitForSeconds(duration);
        doubledamagemodifier = false;
    }
    // Update is called once per frame
    void Update()
    {
        shotgunammo = Math.Clamp(shotgunammo, 0, 24);
        machinegunammo = Math.Clamp(machinegunammo, 0, 180);
        blackholeammo = Math.Clamp(blackholeammo, 0, 3);
        healthvalue = Math.Clamp(healthvalue, 0, 100);
    }
}
