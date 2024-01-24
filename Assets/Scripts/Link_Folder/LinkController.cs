using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.InputSystem.InputAction;

public class LinkController : MonoBehaviour
{
    //el código de control del personaje como tal va aquí. Esto coje los inputs y los transforma en acciones

    private CharacterMovement _chMovement;

    void Start()
    {
        _chMovement = GetComponent<CharacterMovement>();
    }

    //mueve al personaje en una de las 4 direcciones básicas según el input
    public void MoveLink(InputAction.CallbackContext context)
    {
        _chMovement.SetCharacterVelocity(GetGreaterAxis(context.ReadValue<Vector2>()));
    }

    //devuelve el vector de input pero transformado en un vector unitario en una de las 4 direcciones
    Vector2 GetGreaterAxis(Vector2 direction)
    {
        if(Mathf.Abs(direction.x) >= Mathf.Abs(direction.y))
        {
            return new Vector2(direction.x, 0).normalized;
        }
        else
        {
            return new Vector2(0, direction.y).normalized;
        }
    }
}
