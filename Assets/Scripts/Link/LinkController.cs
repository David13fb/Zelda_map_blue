using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.InputSystem.InputAction;

public class LinkController : MonoBehaviour
{
    //el c�digo de control del personaje como tal va aqu�. Esto coje los inputs y los transforma en acciones

    private CharacterMovement _chMovement;
    private bool _blockMovement;

    void Start()
    {
        _chMovement = GetComponent<CharacterMovement>();
    }

    //mueve al personaje en una de las 4 direcciones b�sicas seg�n el input
    public void MoveLink(Vector2 inputDirection)
    {
        if(!_blockMovement)
            _chMovement.SetCharacterVelocity(GetGreaterAxis(inputDirection));
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

    public void SetBlockMovement(bool newValue)
    {
        _blockMovement = newValue;
        _chMovement.SetCharacterVelocity(Vector2.zero);
    }
}
