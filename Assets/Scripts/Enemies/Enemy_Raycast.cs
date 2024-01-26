using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Raycast : MonoBehaviour
{
    [SerializeField] float distance = 10f;
    Transform _myTransform;
    RaycastHit2D hitRight;
    RaycastHit2D hitLeft;
    RaycastHit2D hitUp;
    RaycastHit2D hit;

    // Start is called before the first frame update
    void Start()
    {
        _myTransform = transform;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        hit = Physics2D.Raycast(_myTransform.position, transform.right, distance);
        if (hit.collider != null)
        {

        }
        else
        {
            Debug.DrawRay(transform.position, transform.right, Color.black);
        }
    }
}
