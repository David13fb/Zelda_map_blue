using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class LinkAttack : MonoBehaviour
{
    [SerializeField]
    private GameObject _sword;
    [SerializeField]
    private GameObject _bomb;
    [SerializeField]
    Transform _swordPos;
    LinkAnimatorComponent _anim;

    [SerializeField]
    private HP_manager _hpManager;

    [SerializeField]
    private ShootingComponent _shootingComponent;

    private Transform _linkTransform;

    private float _offset = 1.0f;

    private Rigidbody2D _myRb;

    private Vector3 _attackDirection = Vector3.right;
    private Vector2 _oldInput = Vector2.zero;
    private Vector2 _input = Vector2.zero;
    private GameObject _swordInstance;
    private GameObject _bombInstance;
    private LinkController _linkController;



    void Start()
    {
        _linkController = GetComponent<LinkController>();
        _anim = FindAnyObjectByType<LinkAnimatorComponent>();
        _linkTransform = transform;
        _myRb = GetComponent<Rigidbody2D>();
        _shootingComponent = GetComponent<ShootingComponent>();
    }
    public void inputvector(Vector2 input)
    {
        _input = input;
        if (_input != Vector2.zero)
        {
            _oldInput = _input;

        }

    }
    public void Attack(bool attacked, bool bomb)
    {
        if (!InventoryManager.Instance.itemsUnlocked[0]) return;

        if (attacked || bomb)
        {
            if (_oldInput.x == 1)
            {
                _attackDirection = Vector3.right;
            }

            else if (_oldInput.x == -1)
            {
                _attackDirection = Vector3.left;
            }

            else if (_oldInput.y == 1)
            {
                _attackDirection = Vector3.up;
            }

            else if (_oldInput.y == -1)
            {
                _attackDirection = Vector3.down;
            }
            if (_hpManager.IsFullHP())
            {
                _shootingComponent.Shoot();
            }
            if (attacked && !bomb)
            {
                _swordInstance = Instantiate(_sword, _linkTransform.position + (_offset * _attackDirection), _linkTransform.rotation);
                _anim.UpdateAttackSword(true);
                _linkController.SetBlockMovement(true);
            }
            else if (!attacked && bomb)
            {
                _bombInstance = Instantiate(_bomb, _linkTransform.position + (_offset * _attackDirection), _linkTransform.rotation);
            }
        }
        else if (!attacked && !bomb)
        {
            Destroy(_swordInstance);
            _linkController.SetBlockMovement(false);
            _anim.UpdateAttackSword(false);
        }
    }
}
