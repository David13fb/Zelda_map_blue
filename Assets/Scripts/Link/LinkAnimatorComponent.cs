using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinkAnimatorComponent : MonoBehaviour
{
    [SerializeField]
    private Animator _animator;

    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
    }


    public void UpdateMoveAnimation(Vector2 input)
    {
        _animator.SetInteger("xMove", (int)Mathf.Round(input.x));
        _animator.SetInteger("yMove", (int)Mathf.Round(input.y));
    }
}
