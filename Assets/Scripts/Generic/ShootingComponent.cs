using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;

public class ShootingComponent : MonoBehaviour
{
    [SerializeField]
    private GameObject _bullet; //qué dispara

    private Transform _myTransform; //quién dispara

    [SerializeField]
    private Transform _targetPosition; //a qué dispara


    public Vector3 targetVector;

    [SerializeField]
    private bool _isPlayer = false;

    private float _offset = 1.0f;

    private Rigidbody2D _myRb;

    private Vector3 _shootDirection = Vector3.right;
    void Start()
    {
        _myTransform = transform;
        _myRb = GetComponent<Rigidbody2D>();
    }

    public void Shoot()
    {
        //if (_isPlayer)
        //{
        //    if (_myRb.velocity.x != 0 || _myRb.velocity.y != 0)
        //    {
        //        if (_myRb.velocity.x > 0)
        //        {
        //            _shootDirection = Vector3.right;
        //        }

        //        else if (_myRb.velocity.x < 0)
        //        {
        //            _shootDirection = Vector3.left;
        //        }

        //        else if (_myRb.velocity.y > 0)
        //        {
        //            _shootDirection = Vector3.up;
        //        }

        //        else if (_myRb.velocity.y < 0)
        //        {
        //            _shootDirection = Vector3.down;
        //        }

        //    }


        //    GameObject newBullet = Instantiate(_bullet, _myTransform.position + (_offset * _shootDirection), _myTransform.rotation);
        //    BulletComponent bulletComponent = newBullet.GetComponent<BulletComponent>();
        //    bulletComponent.SetLinkSwordDirection(_shootDirection);
        //}
        //else
        {
            GameObject newBullet = Instantiate(_bullet, _myTransform.position, Quaternion.identity);
            BulletComponent bulletComponent = newBullet.GetComponent<BulletComponent>();
            if(_targetPosition != null)
                bulletComponent.SetDirection(_targetPosition);

        }
    }

}