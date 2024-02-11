using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using Unity.Collections;
using UnityEngine;

public class ShootingComponent : MonoBehaviour
{
    [SerializeField]
    private GameObject _bullet; //qué dispara

    private Transform _myTransform; //quién dispara

    [SerializeField]
    private Transform _targetPosition; //a qué dispara


    //GUARRADA PARA LOS MOBLINS

    [SerializeField]
    private GameObject _arrowUp;

    [SerializeField]
    private GameObject _arrowDown;

    [SerializeField]
    private GameObject _arrowLeft;

    [SerializeField]
    private GameObject _arrowRight;

    private Vector3 _looking;


    private Stopwatch _cdShoot;

    private float _cdShootTime = 3000f;

    /// ///////////////////////////


    public Vector3 targetVector;

    [SerializeField]
    private bool _isMoblin = false;

    private float _offset = 1.0f;

    private Rigidbody2D _myRb;

    private Vector3 _shootDirection = Vector3.right;
    void Start()
    {
        _myTransform = transform;
        _myRb = GetComponent<Rigidbody2D>();

        _cdShoot = new Stopwatch();
        _cdShoot.Start();
    }

    public void Shoot()
    {

        if (_cdShoot.ElapsedMilliseconds > _cdShootTime)
        {
            _cdShoot.Restart();

            if (_isMoblin)
            {

                if (_looking == Vector3.up)
                {
                    GameObject newArrow = Instantiate(_arrowUp, _myTransform.position, Quaternion.identity);

                    BulletComponent bulletComponent = newArrow.GetComponent<BulletComponent>();

                    if (_targetPosition != null)
                        bulletComponent.SetDirection(_targetPosition);
                }
                else if (_looking == Vector3.down)
                {
                    GameObject newArrow = Instantiate(_arrowDown, _myTransform.position, Quaternion.identity);

                    BulletComponent bulletComponent = newArrow.GetComponent<BulletComponent>();

                    if (_targetPosition != null)
                        bulletComponent.SetDirection(_targetPosition);
                }

                else if (_looking == Vector3.left)
                {
                    GameObject newArrow = Instantiate(_arrowLeft, _myTransform.position, Quaternion.identity);

                    BulletComponent bulletComponent = newArrow.GetComponent<BulletComponent>();

                    if (_targetPosition != null)
                        bulletComponent.SetDirection(_targetPosition);
                }

                else if (_looking == Vector3.right)
                {
                    GameObject newArrow = Instantiate(_arrowRight, _myTransform.position, Quaternion.identity);

                    BulletComponent bulletComponent = newArrow.GetComponent<BulletComponent>();

                    if (_targetPosition != null)
                        bulletComponent.SetDirection(_targetPosition);
                }


            }


            else
            {

                GameObject newBullet = Instantiate(_bullet, _myTransform.position, Quaternion.identity);

                BulletComponent bulletComponent = newBullet.GetComponent<BulletComponent>();

                if (_targetPosition != null)
                    bulletComponent.SetDirection(_targetPosition);

            }


        }
    }
    private void Update()
    {
        if (_myRb.velocity.x != 0 || _myRb.velocity.y != 0)
        {
            if (_myRb.velocity.x > 0)
            {
                _looking = Vector3.right;
            }

            else if (_myRb.velocity.x < 0)
            {
                _looking = Vector3.left;
            }

            else if (_myRb.velocity.y > 0)
            {
                _looking = Vector3.up;
            }

            else if (_myRb.velocity.y < 0)
            {
                _looking = Vector3.down;
            }
        }
    }

}