using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinkAnimatorComponent : MonoBehaviour
{
    [SerializeField]
    private Animator _animator;

    //private Rigidbody2D _rb;

    // Start is called before the first frame update
    void Start()
    {
        //_rb = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        /*
        _animator.SetInteger("xMove", (int)Mathf.Round(_rb.velocity.x));
        _animator.SetInteger("yMove", (int)Mathf.Round(_rb.velocity.y));
        */
    }

    public void UpdateMoveAnimation(Vector2 input)
    {
        Debug.Log(input);
        _animator.SetInteger("xMove", (int)Mathf.Round(input.x));
        _animator.SetInteger("yMove", (int)Mathf.Round(input.y));
    }
}
