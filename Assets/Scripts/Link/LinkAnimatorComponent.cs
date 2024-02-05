using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows;

public class LinkAnimatorComponent : MonoBehaviour
{
    [SerializeField]
    private Animator _animator;
    [SerializeField] Transform _transform;
    private LinkController _controller;
    Vector3 _lastposition;

    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
        _transform = transform;
        _lastposition = _transform.position;
        _controller = GetComponent<LinkController>();
    }


    public void LateUpdateMoveAnimation(Vector2 input)
    {

       //if (_lastposition!= _transform.position) 
      //  {
        _animator.SetInteger("xMove", (int)Mathf.Round(input.x));
        _animator.SetInteger("yMove", (int)Mathf.Round(input.y));
      //  }
     

        _lastposition = _transform.position;
    }
    public void UpdateAttackSword(bool attack)
    {
        _animator.SetBool("attacking", attack);
      
    }

    public void ItemPicked(int typeItem)
    {
        if (typeItem == 2)
        {

            _animator.SetTrigger("ItemHeart");
           // await _controller.FreezeCharacter(1);
            

        }
        else if (typeItem == 1) 
        {
            _animator.SetTrigger("ItemSword");
  
           // await _controller.FreezeCharacter(1);
         
        }
            
       

    }

    public void LinkIsDead()
    {
        _animator.SetBool("LinkDeath", true);
    }


}
