using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Despawn1 : MonoBehaviour
{
    private LinkAnimatorComponent _link;
    [SerializeField]
    private TektiteAnimator _tektite;

    private void Start()
    {
        _link = FindAnyObjectByType<LinkAnimatorComponent>();

    }

    void OnTriggerEnter2D(Collider2D linkCollider)
    {

        if (linkCollider.gameObject.GetComponent<LinkController>() != null)
        {

            _tektite.Activate(false);
            Destroy(gameObject);
        }
    }
}
