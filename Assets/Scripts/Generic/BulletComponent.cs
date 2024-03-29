using System.Collections;
using System.Collections.Generic;
//using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class BulletComponent : MonoBehaviour
{ 
    [SerializeField] private float _speed = 10.0f;

    public Vector2 DirectionToCounter { get { return -1 * new Vector2(_direction.x, _direction.y); } }

    private Transform _myTransform;
    private Vector3 _direction; 

    //Sets the direction of the bullet, shooter invokes this method
    public void SetDirection(Transform direct)
    {
        _direction = direct.position - _myTransform.position;
        _direction = _direction.normalized;
    }

    public void SetDirection(Vector3 direct)
    {
        _direction = direct - _myTransform.position;
        _direction = _direction.normalized;
    }
    public void SetLinkSwordDirection(Vector3 direction)
    {
        _direction = direction;
        _direction.Normalize();
        
    }

    void Awake()
    {
        _myTransform = transform;
    }

    //moves the bullet
    void Update()
    {
        //Debug.Log(_direction);
        _myTransform.position += _direction * _speed * Time.deltaTime;
        if(_direction.magnitude * _speed == 0) Destroy(gameObject);
    }

    //Destroys the bullet if not on sight
    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

}
