using UnityEngine;

public class GameManager : MonoBehaviour
{
    public enum WEAPONMODE{
        Pistolmode,
        Machinegunmode
    }
    public static GameManager Instance { get; private set; }
    public float healthvalue;
    public GameObject player;
    public float damage;
    public int weaponmode = 0;
    public float machinegunfirerate;

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
    public void OnHeartMissed()
    {
        SoundManager.Instance.PlayHeartMissedSound();
    }
    
    // Update is called once per frame
    void Update()
    {

    }
}
