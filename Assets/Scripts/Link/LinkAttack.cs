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

    private GameObject _swordInstance;
    private LinkController _linkController;
    
    
    void Start()
    {
        _linkController = GetComponent<LinkController>();
        _anim = FindAnyObjectByType<LinkAnimatorComponent>();
        _linkTransform = transform;
        _myRb = GetComponent<Rigidbody2D>();
    }

    public void Attack(bool attacked, Vector2 Input)
    {
        if (!InventoryManager.Instance.itemsUnlocked[0]) return;

        if(attacked)
        {
            // if ( Input != _oldInput )
           // {
                if (Input != Vector2.zero)
                {
                    _oldInput = Input;
                UnityEngine.Debug.Log(_oldInput);
                }
                if (_oldInput.x > 0)
                {
                    _attackDirection = Vector3.right;
                }

                else if (_oldInput.x < 0)
                {
                    _attackDirection = Vector3.left;
                }

                else if (_oldInput.y > 0)
                {
                    _attackDirection = Vector3.up;
                }

                else if (_oldInput.y < 0)
                {
                   _attackDirection = Vector3.down;
                }

               
                     
            //}

          //  if (_hpManager.IsFullHP())
           // {
              //  _shootingComponent.Shoot();
           // }
         // else
          // {
                 _swordInstance = Instantiate(_sword, _linkTransform.position + (_offset * _attackDirection), _linkTransform.rotation);
                 _linkController.SetBlockMovement(true);
                 _anim.UpdateAttackSword(true);
                
         //  }
        }
        else
        {
            Destroy(_swordInstance);
            _linkController.SetBlockMovement(false);
            _anim.UpdateAttackSword(false);
        }
    }
} 
