using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class BombScript : MonoBehaviour
{
    [SerializeField] private float explosionTime = 1.0f;
    private CircleCollider2D _circleCollider;
    // Start is called before the first frame update

    private void Start()
    {
        _circleCollider = GetComponent<CircleCollider2D>();
        _circleCollider.enabled = false;
    }
    private void Destroy()
    {
        gameObject.SetActive(false);
    }
    private void Update()
    {
        explosionTime--;
        if (explosionTime < 100)
        {
            _circleCollider.enabled = true;
        }
    }
    private void LateUpdate()
    {
        if (explosionTime < 0)
        {
            Destroy();
        }
    }
}
