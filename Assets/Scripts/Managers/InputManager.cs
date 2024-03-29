using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    [SerializeField] private InputActionReference _movementInput;
    [SerializeField] private InputActionReference _attackInput;
    [SerializeField] private InputActionReference _attackCancelInput;
    [SerializeField] private InputActionReference _ItemInput;
    

    private LinkController _linkController;
    private LinkAttack _linkAttack;
    private LinkAnimatorComponent _linkAnim;
    private LevelManager _levelManager;

    private void Start()
    {
        _linkController = FindObjectOfType<LinkController>();
        _linkAttack = FindObjectOfType<LinkAttack>();
        _linkAnim = FindObjectOfType<LinkAnimatorComponent>();
        _levelManager = FindObjectOfType<LevelManager>();

    }
    private void Awake()
    {
        _attackInput.action.performed += AttackActionPerformed;
        _attackCancelInput.action.performed += AttackCancelled;
        _ItemInput.action.performed += ItemActionPerformed;
    }

    private void OnEnable()
    {
        _movementInput.action.Enable();
        _attackInput.action.Enable();
        _attackCancelInput.action.Enable();
        _ItemInput.action.Enable();
    }

    private void OnDisable()
    {
        _movementInput.action.Disable();
        _attackInput.action.Disable();
        _attackCancelInput.action.Disable();
        _ItemInput.action.Disable();
    }
    private void OnDestroy()
    {
        _attackInput.action.performed -= AttackActionPerformed;
        _attackCancelInput.action.performed -= AttackCancelled;
        _ItemInput.action.performed -= ItemActionPerformed;
    }

    private void Update()
    {
        _linkController.MoveLink(_movementInput.action.ReadValue<Vector2>());
        _linkAnim.LateUpdateMoveAnimation(_movementInput.action.ReadValue<Vector2>());
        _linkAttack.inputvector(_movementInput.action.ReadValue<Vector2>());
        
    }

    private void AttackActionPerformed(InputAction.CallbackContext obj)
    {
        _linkAttack.Attack(true,false);
    }

    private void AttackCancelled(InputAction.CallbackContext obj)
    {
        _linkAttack.Attack(false,false);
    }
    private void ItemActionPerformed(InputAction.CallbackContext obj)
    {
        _linkAttack.Attack(false, true);
        _levelManager.ReloadLevel();
    }
}