using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickSword : MonoBehaviour
{
    private LinkAnimatorComponent _link;
    private void Start()
    {
        _link = FindAnyObjectByType<LinkAnimatorComponent>();
    }

    void OnTriggerEnter2D(Collider2D linkCollider)
    {

        if (linkCollider.gameObject.GetComponent<LinkController>() != null)
        {

            _link.ItemPicked(1);


        }
    }
}
