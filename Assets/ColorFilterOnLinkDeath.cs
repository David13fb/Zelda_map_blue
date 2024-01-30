using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class ColorFilterOnLinkDeath : MonoBehaviour
{
    private PostProcessVolume _postProcessVolume;
    private ColorGrading _cg;

    private float _timer;

    private float _animationDuration;
    [SerializeField]
    private float _initialAnimationDuration = 1.5f;
    [SerializeField]
    private bool _dontTransition = true;

    private void Start()
    {
        _postProcessVolume = GetComponent<PostProcessVolume>();
        _postProcessVolume.profile.TryGetSettings(out _cg);

        _animationDuration = _initialAnimationDuration;
    }

    public void AmbientOcclusionOnOff(bool on)
    {
        _cg.active = on;
    }

    public void DeathScreenColorChange()
    {
        if(Time.time - _timer > _animationDuration)
        {
            int red = (int) (255 - Mathf.Lerp(0, 255, (_initialAnimationDuration - _animationDuration) / _initialAnimationDuration));

            _cg.colorFilter.value = new Color(red,0,0);
            Debug.Log(_cg.colorFilter.value);


            //_cg.colorFilter.value = Color.black;
            _animationDuration *= 0.8f;
            _timer = Time.time;
            if (_animationDuration < 0.01f)
            {
                _dontTransition = true;
                _animationDuration = _initialAnimationDuration;
            }
        }
    }

    void Update()
    {
        if (_dontTransition)
        {
            _timer = Time.time;
        } else
            DeathScreenColorChange();
    }
}
