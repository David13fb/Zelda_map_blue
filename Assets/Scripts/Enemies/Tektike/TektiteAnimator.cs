using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem.LowLevel;
using UnityEngine.Windows;

public class TektiteAnimator : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    private bool jump;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    public void Jump(bool state)
    {
        jump = state;
        Move(); 
    }

    public void Move()
    {
        if (!jump)
        {
            // Inicia la corrutina Wait() para gestionar el salto
            StartCoroutine(Wait());
        }
        else
        {
            // Establece la animaci�n para el caso no jump
            _animator.SetBool("Move", true); // Esto podr�a requerir un manejo diferente seg�n tus requisitos
        }
    }

    IEnumerator Wait()
    {
        // Espera antes de cambiar el estado de la animaci�n
        yield return new WaitForSeconds(0.8f);
        _animator.SetBool("Move", false);
        // Espera antes de restaurar el estado de la animaci�n
        yield return new WaitForSeconds(0.8f);
        _animator.SetBool("Move", true);
        yield return new WaitForSeconds(0.9f);
        Move();
    }
}

