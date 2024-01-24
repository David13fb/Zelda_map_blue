using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinkController : MonoBehaviour
{
    //el código de control del personaje como tal va aquí. Esto coje los inputs y los transforma en acciones

    private CharacterMovement _chMovement;
    private InputManager _inputManager;

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
        if(Mathf.Abs(_inputManager.inputVector.x) >= Mathf.Abs(_inputManager.inputVector.y))
        {
            return new Vector2(_inputManager.inputVector.x, 0).normalized;
        }
        else
        {
            return new Vector2(0, _inputManager.inputVector.y).normalized;
        }
    }
}
