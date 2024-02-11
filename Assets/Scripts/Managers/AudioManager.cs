using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] Transform _cameraTransform;
    [SerializeField] AudioSource _musicAudioSource, _sfxAudioSource;


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
