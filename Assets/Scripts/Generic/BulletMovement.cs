using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : MonoBehaviour
{ 
    [SerializeField]
    private float _speed = 10.0f;
    private Transform _myTransform;
    private Vector3 _direction;
   

    public void SetDirection(Transform direct)
    {
        _direction = direct.position - _myTransform.position;
    }

    void Start()
    {
        _myTransform = transform;

    }
    void Update()
    {
        _myTransform.position += _direction.normalized * _speed * Time.deltaTime;
    }

}
