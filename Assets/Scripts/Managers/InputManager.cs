using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    [SerializeField] private InputActionReference _movementInput;
    [SerializeField] private InputActionReference _attackInput;

    private LinkController _linkController;
    private LinkAttack _linkAttack;
    private void Start()
    {
        _linkController = FindObjectOfType<LinkController>();
        _linkAttack = FindObjectOfType<LinkAttack>();

    }

    private void Update()
    {
        _linkController.MoveLink(_movementInput.action.ReadValue<Vector2>());
    }

    
}
