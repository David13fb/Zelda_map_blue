using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.InputSystem.InputAction;

public class InputManager : MonoBehaviour
{
    static InputManager _instance;

    static Vector2 _inputVector;


    void Start()
    {
        //Singleton patern
        if(_instance == null)
        {
            _instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    public void updateDirectionalInputVector(InputAction.CallbackContext context)
    {
        _inputVector = context.ReadValue<Vector2>();
    }


}
