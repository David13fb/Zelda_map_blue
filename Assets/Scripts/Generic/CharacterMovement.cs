using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    [SerializeField]
    private float _speed = 1.0f;

    public ContactFilter2D movementFilter;
    public bool NotMoving { get { return _rb.velocity == Vector2.zero; } }


    private Transform _transform;
    private Rigidbody2D _rb;
    Vector2 actualspeed = Vector2.zero;
    Vector2 targetspeed = Vector2.zero;
   
    void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    public void SetCharacterVelocity(Vector2 direction)
    {
        if (_rb == null) return;
        _rb.velocity = direction.normalized * _speed;
    }

    void Update()
    {
        if(_rb.velocity.magnitude > _speed)
        {
            Debug.Log("Te pasaste");
        }
    }
}