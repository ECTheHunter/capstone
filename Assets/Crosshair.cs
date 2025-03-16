using UnityEngine;

public class Crosshair : MonoBehaviour
{
    [SerializeField] private Texture2D currentcross;
    [SerializeField] private Texture2D pistolcross;
    [SerializeField] private Texture2D machinecross;
    [SerializeField] private Texture2D shotguncross;
    [SerializeField] private Texture2D blackholecross;
    private Vector2 currenthotspot;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        switch (GameManager.Instance.weaponmode)
        {
            case (int)GameManager.WEAPONMODE.Pistolmode:
                currentcross = pistolcross;
                break;
            case (int)GameManager.WEAPONMODE.Machinegunmode:
                currentcross = machinecross;
                break;
            case (int)GameManager.WEAPONMODE.Shotgunmode:
                currentcross = shotguncross;
                break;
            case (int)GameManager.WEAPONMODE.BlackHolemode:
                currentcross = blackholecross;
                break;
        }
        currenthotspot = new Vector2(currentcross.width / 2, currentcross.height / 2);
        Cursor.SetCursor(currentcross, currenthotspot, CursorMode.ForceSoftware);
    }

}
