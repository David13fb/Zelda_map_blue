using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Windows;

public class TektiteAnimator : MonoBehaviour
{
    [SerializeField] private Animator _animator;

    private bool jump= false;
    private float _jumptime = 0.6f;
    private float _longJumpTime = 1.0f;

    private void Start()
    {
        _animator = GetComponent<Animator>();
     
        StartCoroutine(Move());
       
    }

   private void Jump(bool newState)
    {
        jump = newState;
        if (jump)
        {
            _jumptime = _longJumpTime; 
        }
        else
        {
            _jumptime = 0.6f; 
        }
    }
   
    private IEnumerator Move()
    {
        while (true)
        {
            // Animación "down"
            _animator.SetBool("Move", true);
            yield return new WaitForSeconds(0.6f);

            // Animación "up"
            _animator.SetBool("Move", false);
            yield return new WaitForSeconds(_jumptime);
        }
    }

}

