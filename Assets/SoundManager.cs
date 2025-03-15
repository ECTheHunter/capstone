using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance { get; private set; }

    [Header("Audio Sources")]
    public AudioSource sfxSource;
    public AudioSource musicSource;

    [Header("Audio Clips")]
    public AudioClip regularenemyDestroyedClip;
    public AudioClip pistolFiredClip;
    public AudioClip baseTakeDamageClip;
    public AudioClip music;
<<<<<<< HEAD
    public AudioClip shotgun;
    public AudioClip machineGun;
    public AudioClip enemyDestroyed1Clip;
    public AudioClip gameOver;
=======
    public AudioClip shotgunFiredClip;
    public AudioClip machinegunFiredClip;
    public AudioClip bouncingDestroyedClip;
>>>>>>> 81a3b753a08cc11060eb3f085d377cdd4d925a58

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        musicSource.clip = music;
        musicSource.Play();
    }
    private void Update()
    {

    }
    public void PlaySound(AudioClip sound)
    {
        sfxSource.PlayOneShot(sound);
    }
}