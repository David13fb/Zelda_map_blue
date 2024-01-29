using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : MonoBehaviour
{ 
    [SerializeField] private float _speed = 10.0f;

    private Transform _myTransform;
    private Vector3 _direction;

    [SerializeField] private float _lifeTime = 10.0f;
   

    public void SetDirection(Transform direct)
    {
        _direction = direct.position - _myTransform.position;
        _direction = _direction.normalized;
    }

    //Si pones start se rompe :(
    void Awake()
    {
        _myTransform = transform;
        Destroy(gameObject, _lifeTime);
    }
    void Update()
    {
        _myTransform.position += _direction * _speed * Time.deltaTime;
    }

}
