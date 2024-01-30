using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinkAnimatorComponent : MonoBehaviour
{
    [SerializeField]
    private Animator _animator;
    [SerializeField] Transform _transform;
    Vector3 _lastposition;

    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
        _transform = transform;
        _lastposition = _transform.position;
    }


    public void LateUpdateMoveAnimation(Vector2 input)
    {

       if (_lastposition!= _transform.position) 
        {
        _animator.speed = 1;

        _animator.SetInteger("xMove", (int)Mathf.Round(input.x));
        _animator.SetInteger("yMove", (int)Mathf.Round(input.y));
        }
      else _animator.speed = 0;

        _lastposition = _transform.position;
    }
    public void UpdateAttackSword(bool attack)
    {
        _animator.SetBool("attacking", attack);
        if (attack)
        {
            _animator.speed = 0;
        }
        else _animator.speed = 1;
    }
}
