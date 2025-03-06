using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance { get; private set; }

    [Header("Audio Sources")]
    public AudioSource sfxSource;
    public AudioSource musicSource;

    [Header("Audio Clips")]
    public AudioClip enemyShotClip;
    public AudioClip gunFiredClip;
    public AudioClip heartMissedClip;

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
    }

    public void PlayEnemyShotSound()
    {
        sfxSource.PlayOneShot(enemyShotClip);
    }

    public void PlayGunFiredSound()
    {
        sfxSource.PlayOneShot(gunFiredClip);
    }

    public void PlayHeartMissedSound()
    {
        sfxSource.PlayOneShot(heartMissedClip);
    }
}