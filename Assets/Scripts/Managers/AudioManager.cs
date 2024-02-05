using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance { get; private set; } //singleton
    [SerializeField] Transform _cameraTransform;
    [SerializeField] AudioSource _musicAudioSource, _sfxAudioSource;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(this);
        }
    }

    public void PlaySoundEffect(AudioClip clip)
    {
        _sfxAudioSource.PlayOneShot(clip);
    }

    public void PlayOrStopMusic(bool play)
    {
        if (play)
        {
            _musicAudioSource.Play();
        }
        else _musicAudioSource.Stop();
    }

}
