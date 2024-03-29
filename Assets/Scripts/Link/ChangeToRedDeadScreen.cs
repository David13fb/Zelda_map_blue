using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeToRedDeadScreen : MonoBehaviour
{
    Image _image;

    [SerializeField]
    private GameObject _loseGameScreen;

    private float _timer;

    private GameManager _gameManager;

    private float _animationDuration;
    [SerializeField]
    private float _initialAnimationDuration = 1.5f;
    [SerializeField]
    private float _shortenAnimationBy = 0.6f;
    [SerializeField]
    private bool _dontTransition = true;

    void Start()
    {
        _image = GetComponent<Image>();
        _animationDuration = _initialAnimationDuration;
        _gameManager = FindAnyObjectByType<GameManager>();
    }

    public void DeathScreenColorChange()
    {
        if (Time.unscaledTime - _timer > _animationDuration)
        {
            byte red = (byte)(255 - Mathf.Lerp(0, 255, (_initialAnimationDuration - _animationDuration) / _initialAnimationDuration));
            _image.color = new Color32(red, 0, 0, 255);
            //Debug.Log(_image.color);
            //_cg.colorFilter.value = Color.black;
            _animationDuration *= _shortenAnimationBy;
            _timer = Time.unscaledTime;
            if (_animationDuration < 0.01f)
            {
                _dontTransition = true;
                _animationDuration = _initialAnimationDuration;
                _gameManager.DeathAnimationFinished();
            }
        }
    }

    void Update()
    {
        if (_dontTransition)
        {
            _timer = Time.unscaledTime;
        }
        else
            DeathScreenColorChange();
    }

    public void SetDeathScreenColorChange()
    {
        _dontTransition = false;
    }

    public void SpawnLoseGame()
    {
        Instantiate(_loseGameScreen);
    }
}
