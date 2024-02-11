using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DespawnLeever : MonoBehaviour
{
    private LinkAnimatorComponent _link;
    [SerializeField]
    private LeeverAnimator _leever;
    private void Start()
    {
        _link = FindAnyObjectByType<LinkAnimatorComponent>();

    }

    void OnTriggerEnter2D(Collider2D linkCollider)
    {

        if (linkCollider.gameObject.GetComponent<LinkController>() != null)
        {

            _leever.Activate(false);
            Destroy(gameObject);
        }
    }
}
