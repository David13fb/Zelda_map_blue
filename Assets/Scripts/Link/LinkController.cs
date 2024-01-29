using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.InputSystem.InputAction;
using Task = System.Threading.Tasks.Task;

public class LinkController : MonoBehaviour
{
    //el c�digo de control del personaje como tal va aqu�. Esto coje los inputs y los transforma en acciones

    private CharacterMovement _chMovement;
    private bool _blockMovement = false;

    void Start()
    {
        _chMovement = GetComponent<CharacterMovement>();
    }

    //mueve al personaje en una de las 4 direcciones b�sicas seg�n el input
    public void MoveLink(Vector2 inputDirection)
    {
        // Debug.Log(inputDirection);
        //Debug.Log(_blockMovement);
        if(!_blockMovement)
            _chMovement.SetCharacterVelocity(inputDirection);
    }

    //devuelve el vector de input pero transformado en un vector unitario en una de las 4 direcciones
    //Vector2 GetGreaterAxis(Vector2 direction)
    //{
    //    if(Mathf.Abs(direction.x) >= Mathf.Abs(direction.y))
    //    {
    //        return new Vector2(direction.x, 0).normalized;
    //    }
    //    else
    //    {
    //        return new Vector2(0, direction.y).normalized;
    //    }
    //}

    // this method is called when we need to freeze the character for a certain amount of time
    public async Task FreezeCharacter(float seconds)
    {
        SetBlockMovement(true);
        await Task.Delay((int)(seconds * 1000));
        SetBlockMovement(false);
    }

    // this method changes the value of the blockMovement private variable
    public void SetBlockMovement(bool newValue)
    {
        _blockMovement = newValue;
        _chMovement.SetCharacterVelocity(Vector2.zero);
    }
}
