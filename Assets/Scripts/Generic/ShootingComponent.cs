using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingComponent : MonoBehaviour
{
    [SerializeField]
    private GameObject _bullet; //qu� dispara

    private Transform _myTransform; //qui�n dispara

    [SerializeField]
    private Transform _targetPosition; //a qu� dispara
    void Start()
    {
        _myTransform = transform;
    }

    public void Shoot()
    {
            GameObject newBala = Instantiate(_bullet, _myTransform.position, Quaternion.identity);
            BulletMovement bulletMovement = newBala.GetComponent<BulletMovement>();
            bulletMovement.SetDirection(_targetPosition);
    }

}
