using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : MonoBehaviour
{ 
    [SerializeField]
    private float _speed = 10.0f;
    private Transform _myTransform;
    private Vector3 _direction;
   

    public void SetDirection(Vector3 direct)
    {
        _direction = direct.normalized * _speed;
    }

    void Start()
    {
        _myTransform = transform;

    }
    void Update()
    {
        _myTransform.position += _direction * Time.deltaTime;
    }

}
