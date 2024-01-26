using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    [SerializeField]
    private GameObject _bullet; // que dispara
    [SerializeField]
    private Transform _myTransform; // quien dispara
    private GameObject newbala;
     void Start()
    {
        _bullet = GetComponent<GameObject>();
        _myTransform = transform;
       
    }

    public void Shoot(bool shoot)
    {
        
        if (shoot)
        {
            GameObject newbala = Instantiate(_bullet, _myTransform.position, _myTransform.rotation);
            newbala.GetComponent<BulletMovement>().SetDirection(_myTransform.rotation * Vector3.forward);
        }
       
        else 
        {
            Destroy(newbala);

        }

    }

}
