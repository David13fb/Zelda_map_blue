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
    
    public void Attack(bool attacked)
    {
        if(attacked)
        {
            _swordInstance = Instantiate(_sword, _swordPos.position, Quaternion.identity);
        }
        else
        {
            Destroy(_swordInstance);
        }
    }
} 
