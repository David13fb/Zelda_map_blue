using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HP_manager : MonoBehaviour
{
    [SerializeField]
    int _startingMaxHp;
    int _currentMaxHp;
    int _currenthealth;


    void Start()
    {
        _currentHealth = _currentMaxHp = _startingMaxHp;
    }

    void takeDamage(int damage)
    {
        _currenthealth -= damage;
    }

}
