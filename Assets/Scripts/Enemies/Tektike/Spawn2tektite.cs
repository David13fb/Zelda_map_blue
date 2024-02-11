using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn2tektite : MonoBehaviour
{
    private LinkAnimatorComponent _link;
    [SerializeField]
    private CloudAnimator _cloud;

    private void Start()
    {
        _link = FindAnyObjectByType<LinkAnimatorComponent>();

    }

    void OnTriggerEnter2D(Collider2D linkCollider)
    {

        if (linkCollider.gameObject.GetComponent<LinkController>() != null)
        {

            _cloud.Activate(true);
            Destroy(gameObject);
        }
    }
}
