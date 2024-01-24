using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinkController : MonoBehaviour
{
    //el código de control del personaje como tal va aquí. Esto coje los inputs y los transforma en acciones

    private CharacterMovement _chMovement;

    void Start()
    {
        _chMovement = GetComponent<CharacterMovement>();
    }

    void FixedUpdate()
    {
        MoveLink();
    }

    //mueve al personaje en una de las 4 direcciones básicas según el input
    void MoveLink()
    {
        _chMovement.SetCharacterVelocity(GetGreaterAxis());
        Debug.Log(GetGreaterAxis());
    }

    //devuelve el vector de input pero transformado en un vector unitario en una de las 4 direcciones
    Vector2 GetGreaterAxis()
    {
        if(Mathf.Abs(InputManager.Instance.inputVector.x) >= Mathf.Abs(InputManager.Instance.inputVector.y))
        {
            return new Vector2(InputManager.Instance.inputVector.x, 0).normalized;
        }
        else
        {
            return new Vector2(0, InputManager.Instance.inputVector.y).normalized;
        }
    }
}
