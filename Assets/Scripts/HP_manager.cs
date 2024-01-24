using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HP_manager : MonoBehaviour
{
    [SerializeField]
    //cada corazon son 2 puntos de vida
    int _startingMaxHp = 6;
    [SerializeField]
    int _currentMaxHp;
    [SerializeField]
    int _currentHealth;
    [SerializeField]
    bool _thisIsPlayer = false;
    [SerializeField]
    private HUDmanager _hudManager;


    void Start()
    {
        _currentHealth = _currentMaxHp = _startingMaxHp;
        if (_thisIsPlayer)
            changeHpGauge();
    }

    void changeCurrentHealth(int damage)
    {
        _currentHealth += damage;
        if(_currentHealth > _currentMaxHp)
            _currentHealth = _currentMaxHp;
        

        if (_thisIsPlayer)
            changeHpGauge();


    }

    void changeMaxHealth(int mod)
    {
        _currentMaxHp += mod;
        if (_thisIsPlayer)
            changeHpGauge();
    }

    //actualiza la barra de vida visualmente
    void changeHpGauge()
    {
        _hudManager.UpdateCurrentHP(_currentHealth);
        _hudManager.UpdateHPmaxHP(_currentMaxHp);
    }
}