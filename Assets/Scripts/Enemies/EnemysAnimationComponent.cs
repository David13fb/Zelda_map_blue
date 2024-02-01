using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Windows;

public class EnemysAnimationComponent : MonoBehaviour
{
    [SerializeField]
    private Animator _animator;
    private Rigidbody2D _myRigidbody;
    Vector2 _prevVelocity; //velocidad anterior

    void Start()
    {
        _animator = GetComponent<Animator>(); 
        _myRigidbody = GetComponent<Rigidbody2D>();
        _prevVelocity = _myRigidbody.velocity;
    }


    private void Update()
    {
        if (_prevVelocity != _myRigidbody.velocity)
        {
            _animator.SetFloat("xMove", _myRigidbody.velocity.x);
            _animator.SetFloat("yMove", _myRigidbody.velocity.y);
        }
        _prevVelocity = _myRigidbody.velocity;
    }
}
