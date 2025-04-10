using UnityEngine;

public class AmmoPickUp : PickUpClass
{
    public string ammopickupType;
    public override void pickUpEffect()
    {
        switch (ammopickupType)
        {
            case "MACHINEGUN_60":
                GameManager.Instance.machinegunammo += 60;
                break;
            case "SHOTGUN_8":
                GameManager.Instance.shotgunammo += 8;
                break;
            case "MACHINEGUN_120":
                GameManager.Instance.machinegunammo += 120;
                break;
            case "SHOTGUN_16":
                GameManager.Instance.shotgunammo += 16;
                break;
            case "MACHINEGUN_60+SHOTGUN_8":
                GameManager.Instance.machinegunammo += 60;
                GameManager.Instance.shotgunammo += 8;
                break;
            case "MACHINEGUN_120+SHOTGUN_16":
                GameManager.Instance.machinegunammo += 120;
                GameManager.Instance.shotgunammo += 16;
                break;
            case "MACHINEGUN_60+SHOTGUN_8+BLACKHOLE_1":
                GameManager.Instance.blackholeammo += 1;
                GameManager.Instance.shotgunammo += 8;
                GameManager.Instance.machinegunammo += 60;
                break;
            case "MACHINEGUN_120+SHOTGUN_16+BLACKHOLE_1":
                GameManager.Instance.blackholeammo += 1;
                GameManager.Instance.shotgunammo += 16;
                GameManager.Instance.machinegunammo += 120;
                break;
        }
        Destroy(gameObject);
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        int randomValue = Random.Range(0, 8);
        switch (randomValue)
        {
            case 0:
                ammopickupType = "MACHINEGUN_60";
                break;
            case 1:
                ammopickupType = "SHOTGUN_8";
                break;
            case 2:
                ammopickupType = "MACHINEGUN_60+SHOTGUN_8";
                break;
            case 3:
                ammopickupType = "MACHINEGUN_120+SHOTGUN_16";
                break;
            case 4:
                ammopickupType = "MACHINEGUN_120";
                break;
            case 5:
                ammopickupType = "SHOTGUN_16";
                break;
            case 6:
                ammopickupType = "MACHINEGUN_60+SHOTGUN_8+BLACKHOLE_1";
                break;
            case 7:
                ammopickupType = "MACHINEGUN_120+SHOTGUN_16+BLACKHOLE_1";
                break;


        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
