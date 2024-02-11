using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using TMPro;
using UnityEngine;

public class BombScript : MonoBehaviour
{
    [SerializeField] private float _explosionTime, _timeBeforeDeletion;
    [SerializeField]
    private CircleCollider2D _circleCollider1;
    [SerializeField]
    private CircleCollider2D _circleCollider2;
    [SerializeField] private Animator _animator;
    Transform _transform;

    private Stopwatch _stopwatch = new Stopwatch();
   
    //Audio
    private AudioManager _audioManager;
    [SerializeField] AudioClip _bombAudio, _wallBreakAudio, _secretWallAudio;

    private void Start()
    {
       _transform = transform;
        _audioManager = FindObjectOfType<AudioManager>();
        _animator = GetComponent<Animator>();
       
    }
    private void Update()
    {
        if (_stopwatch.ElapsedMilliseconds > _explosionTime)
        {
            _animator.speed = 1.0f;
            _circleCollider1.enabled = true;
            _circleCollider2.enabled = true;
            Explode();
           
        }
    }
    private void Explode()
    { _audioManager.PlaySoundEffect(_bombAudio);
        _animator.SetBool("explote", true);
        _transform.localScale = Vector3.one*3;
        Destroy(gameObject, _timeBeforeDeletion);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<HP_manager>() == null) 
        {
            GameObject.Destroy(collision.gameObject);
            _audioManager.PlaySoundEffect(_wallBreakAudio);
            _audioManager.PlaySoundEffect(_secretWallAudio);

        }
    }

    private void OnEnable()
    {
        _stopwatch.Start();
       
    }
}
