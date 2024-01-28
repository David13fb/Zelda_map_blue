using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    private Transform _transform;
    private Rigidbody2D _rb;
    [SerializeField]
    private float _speed = 1.0f;
    Vector2 actualspeed = Vector2.zero;
    Vector2 targetspeed = Vector2.zero;
   
    void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    public void SetCharacterVelocity(Vector2 direction)
    {
        
        _rb.velocity = direction * _speed;
    }
}
