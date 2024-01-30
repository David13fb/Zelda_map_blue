using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    [SerializeField] private InputActionReference _movementInput;
    [SerializeField] private InputActionReference _attackInput;
    [SerializeField] private InputActionReference _attackCancelInput;

    private LinkController _linkController;
    private LinkAttack _linkAttack;
    private LinkAnimatorComponent _linkAnim;

    private void Start()
    {
        _linkController = FindObjectOfType<LinkController>();
        _linkAttack = FindObjectOfType<LinkAttack>();
        _linkAnim = FindObjectOfType<LinkAnimatorComponent>();
        

    }
    private void Awake()
    {
        _attackInput.action.performed += AttackActionPerformed;
        _attackCancelInput.action.performed += AttackCancelled;
    }

    private void OnEnable()
    {
        _movementInput.action.Enable();
        _attackInput.action.Enable();
        _attackCancelInput.action.Enable();
    }

    private void OnDisable()
    {
        _movementInput.action.Disable();
        _attackInput.action.Disable();
        _attackCancelInput.action.Disable();
    }
    private void OnDestroy()
    {
        _attackInput.action.performed -= AttackActionPerformed;
        _attackCancelInput.action.performed -= AttackCancelled;
    }

    private void Update()
    {
        _linkController.MoveLink(_movementInput.action.ReadValue<Vector2>());
        _linkAnim.UpdateMoveAnimation(_movementInput.action.ReadValue<Vector2>());
    }

    private void AttackActionPerformed(InputAction.CallbackContext obj)
    {
        _linkAttack.Attack(true);
   
    }

    private void AttackCancelled(InputAction.CallbackContext obj)
    {
        _linkAttack.Attack(false);
    }
}
