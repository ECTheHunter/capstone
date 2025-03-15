using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance { get; private set; }

    [Header("Audio Sources")]
    public AudioSource sfxSource;
    public AudioSource musicSource;

    [Header("Audio Clips")]
    public AudioClip enemyDestroyedClip;
    public AudioClip pistolFiredClip;
    public AudioClip baseTakeDamageClip;
    public AudioClip music;
    public AudioClip shotgun;
    public AudioClip machineGun;
    public AudioClip enemyDestroyed1Clip;
    public AudioClip gameOver;

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
    public void PlaySound(AudioClip sound){
        sfxSource.PlayOneShot(sound);
    }
}