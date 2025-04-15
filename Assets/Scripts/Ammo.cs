using TMPro;
using UnityEngine;

public class Ammo : MonoBehaviour
{
    public TextMeshProUGUI pistolAmmoText;
    public TextMeshProUGUI machinegunAmmoText;
    public TextMeshProUGUI shotgunAmmoText;
    public TextMeshProUGUI blackholeAmmoText;

    void Update()
    {
        if (GameManager.Instance != null)
        {
            // Pistol Ammo
            pistolAmmoText.text = "Unlimited";

            // Machinegun Ammo
            machinegunAmmoText.text = $"{GameManager.Instance.machinegunammo}";

            // Shotgun Ammo
            shotgunAmmoText.text = $"{GameManager.Instance.shotgunammo}";

            // Blackhole Ammo
            blackholeAmmoText.text = $"{GameManager.Instance.blackholeammo}";
        }
        else
        {
            Debug.LogWarning("GameManager instance is null!");
        }
    }
}