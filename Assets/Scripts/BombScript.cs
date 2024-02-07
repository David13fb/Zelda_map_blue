using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class BombScript : MonoBehaviour
{
    [SerializeField] private float explosionTime = 1.0f;

    // Start is called before the first frame update
    private void Start()
    {
        
    }
    private void Update()
    {
            
    }
    public void Bomb() 
    {
        while (explosionTime > 0)
        {
            explosionTime -= Time.deltaTime;
        }
       gameObject.SetActive(false);
    }
}
