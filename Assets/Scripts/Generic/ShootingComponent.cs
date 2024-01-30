using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingComponent : MonoBehaviour
{
    [SerializeField]
    private GameObject _bullet; //qué dispara

    private Transform _myTransform; //quién dispara

    [SerializeField]
    private Transform _targetPosition; //a qué dispara
    void Start()
    {
        _myTransform = transform;
    }

    public void Shoot()
    {
            GameObject newBullet = Instantiate(_bullet, _myTransform.position, Quaternion.identity);
            BulletComponent bulletComponent = newBullet.GetComponent<BulletComponent>();
            bulletComponent.SetDirection(_targetPosition);
    }

}
