using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{

    [SerializeField]
    private float _speed = 1.0f;

    private float collisionOffset = 0.05f;

    public ContactFilter2D movementFilter;

    private Transform _transform;
    private Rigidbody2D _rb;
    private Vector2 _moveDirection;
    private List<RaycastHit2D> castCollisions = new List<RaycastHit2D>();

    
   
    void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    public bool MoveCharacter(Vector2 direction)
    {
        int count = _rb.Cast(
            direction,
            movementFilter,
            castCollisions,
            _speed * Time.deltaTime + collisionOffset
        );
        if (count == 0)
        {
            Vector2 moveVector = direction * _speed * Time.fixedDeltaTime;

            _rb.MovePosition(_rb.position + moveVector);
            return true;
        }
        else
        {
            foreach (RaycastHit2D hit in castCollisions)
            {
                Debug.Log(hit.ToString());
            }
            return false;
        }
    }
}
