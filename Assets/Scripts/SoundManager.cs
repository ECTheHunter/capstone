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
    public AudioClip shotgunFiredClip;
    public AudioClip machinegunFiredClip;
    public AudioClip blackholeFiredClip;
    public AudioClip bouncingDestroyedClip;
    public AudioClip l_rDestroyedClip;

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