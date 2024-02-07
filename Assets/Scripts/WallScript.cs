using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallScript : MonoBehaviour
{
    // Start is called before the first frame update
    private void Start()
    {
        gameObject.SetActive(true);
    }
    private void OnTriggerEnter2D(Collider2D bombColider)
    {
        if (bombColider.gameObject.GetComponent<BombScript>() != null)
        {
            gameObject.SetActive(false);
        }
    }
}
