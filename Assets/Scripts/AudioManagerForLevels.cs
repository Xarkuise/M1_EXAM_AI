using UnityEngine;

public class AudioManagerForLevels : MonoBehaviour
{
    [SerializeField] private AudioSource backgroundAudioSource; // For background music
    [SerializeField] private AudioSource sfxAudioSource1; // For general sound effects
    [SerializeField] private AudioSource sfxAudioSource2;
    [SerializeField] private AudioSource sfxAudioSource3;

    [SerializeField] private AudioClip buttonClickSound;
    [SerializeField] private AudioClip backgroundMusic;
    [SerializeField] private AudioClip keyPickupSound;
    [SerializeField] private AudioClip doorOpenSound;

    private void Start()
    {
        // Play the background music at the start
        if (backgroundMusic != null && backgroundAudioSource != null)
        {
            backgroundAudioSource.clip = backgroundMusic;
            backgroundAudioSource.loop = true;
            backgroundAudioSource.Play();
        }
    }

    public void PlayButtonClickSound()
    {
        if (sfxAudioSource1 != null && buttonClickSound != null)
        {
            sfxAudioSource1.PlayOneShot(buttonClickSound);
        }
    }

    public void PlayKeyPickupSound()
    {
        PlaySound(sfxAudioSource2, keyPickupSound);
    }

    public void PlayDoorOpenSound()
    {
        PlaySound(sfxAudioSource3, doorOpenSound);
    }

    private void PlaySound(AudioSource source, AudioClip clip)
    {
        if (source != null && clip != null)
        {
            source.PlayOneShot(clip);
        }
    }
}
