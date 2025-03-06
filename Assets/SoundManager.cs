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

    public void PlayEnemyDestroyedSound()
    {
        sfxSource.PlayOneShot(enemyDestroyedClip);
    }

    public void PlayPistolFiredSound()
    {
        sfxSource.PlayOneShot(pistolFiredClip);
    }

    public void PlayBaseTakeDamageSound()
    {
        sfxSource.PlayOneShot(baseTakeDamageClip);
    }
}