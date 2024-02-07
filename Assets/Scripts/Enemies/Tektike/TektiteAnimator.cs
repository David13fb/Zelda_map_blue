using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Windows;

public class TektiteAnimator : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    private bool jump;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        
    }


    private void Jump(bool newState)
    {
        jump = newState;
        StartCoroutine(Move());
    }

         IEnumerator Move()
         {
        if (jump)
        {
            //time should be adapted with duration of displacement in the IA
            // Animaci�n "up"
            _animator.SetBool("Move", false);
            yield return new WaitForSeconds(1.3f);

            // Animaci�n "down"
            _animator.SetBool("Move", true);
            yield return new WaitForSeconds(0.8f);

        }
        else 
        {

            // Animaci�n "up"
            _animator.SetBool("Move", false);
            yield return new WaitForSeconds(0.8f);

            // Animaci�n "down"
            _animator.SetBool("Move", true);
            yield return new WaitForSeconds(0.8f);



        }


           



        
         }
}

