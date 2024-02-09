using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class BombScript : MonoBehaviour
{
    [SerializeField] private float explosionTime = 1.0f;
    [SerializeField]
    private CircleCollider2D _circleCollider1;
    [SerializeField]
    private CircleCollider2D _circleCollider2;
    // Start is called before the first frame update

    private void Destroy()
    {
        gameObject.SetActive(false);
    }
    private void Update()
    {
        explosionTime--;
        if (explosionTime < 100)
        {
            _circleCollider1.enabled = true;
            _circleCollider2.enabled = true;
           
        }
    }
    private void LateUpdate()
    {
        if (explosionTime < 0)
        {
            Destroy();
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.GetComponent<HP_manager>() == null) GameObject.Destroy(collision.gameObject);
    }
}
