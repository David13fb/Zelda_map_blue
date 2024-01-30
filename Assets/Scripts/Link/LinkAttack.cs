using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class LinkAttack : MonoBehaviour
{
    [SerializeField]
    private GameObject _sword;
    [SerializeField]
    Transform _swordPos;
    LinkAnimatorComponent _anim;

    private GameObject _swordInstance;
    private LinkController _linkController;
    
    void Start()
    {
        _linkController = GetComponent<LinkController>();
        _anim = FindAnyObjectByType<LinkAnimatorComponent>();
    }

    public void Attack(bool attacked)
    {
        if (!InventoryManager.Instance.itemsUnlocked[0]) return;

        if(attacked)
        {
            _swordInstance = Instantiate(_sword, _swordPos.position, Quaternion.identity);
            _linkController.SetBlockMovement(true);
            _anim.UpdateAttackSword(true);
        }
        else
        {
            Destroy(_swordInstance);
            _linkController.SetBlockMovement(false);
            _anim.UpdateAttackSword(false);
        }
    }
} 
