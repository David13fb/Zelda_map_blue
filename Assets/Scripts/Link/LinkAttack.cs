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

    private GameObject _swordInstance;
    private LinkController _linkController;
    
    void Start()
    {
        _linkController = GetComponent<LinkController>();
    }

    public void Attack(bool attacked)
    {
        if(attacked)
        {
            _swordInstance = Instantiate(_sword, _swordPos.position, Quaternion.identity);
            _linkController.SetBlockMovement(true);
        }
        else
        {
            Destroy(_swordInstance);
            _linkController.SetBlockMovement(false);
        }
    }
} 
