using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class GunPanels : MonoBehaviour
{
    public GameObject GunUI;
    // Pistol seçimi
    public void SelectPistol()
    {
        if (GameManager.Instance == null)
        {
            Debug.LogError("GameManager.Instance null durumda! GameManager sahnede mevcut mu?");
        }

        GameManager.Instance.weaponmode = (int)GameManager.WEAPONMODE.Pistolmode;
        Debug.Log("Pistol silahı seçildi.");
    }

    // Machinegun seçimi
    public void SelectMachinegun()
    {
        GameManager.Instance.weaponmode = (int)GameManager.WEAPONMODE.Machinegunmode;
        Debug.Log("Machinegun silahı seçildi.");
    }

    // Shotgun seçimi
    public void SelectShotgun()
    {
        GameManager.Instance.weaponmode = (int)GameManager.WEAPONMODE.Shotgunmode;
        Debug.Log("Shotgun silahı seçildi.");
    }

    // Blackhole seçimi
    public void SelectBlackhole()
    {
        GameManager.Instance.weaponmode = (int)GameManager.WEAPONMODE.BlackHolemode;
        Debug.Log("Shotgun silahı seçildi.");
    }
}