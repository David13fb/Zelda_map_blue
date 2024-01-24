using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.InputSystem.InputAction;

public class InputManager : MonoBehaviour
{
    public InputManager Instance;

    //[HideInInspector]
    public Vector2 inputVector;

    public void updateDirectionalInputVector(InputAction.CallbackContext context)
    {
        inputVector = context.ReadValue<Vector2>();
    }


}
