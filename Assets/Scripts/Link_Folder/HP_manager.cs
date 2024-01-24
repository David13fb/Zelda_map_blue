using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HP_manager : MonoBehaviour
{
    [SerializeField]
    //cada corazon son 2 puntos de vida
    int _startingMaxHp = 3;
    int _currentMaxHp;
    int _currentHealth;


    void Start()
    {
        _currentHealth = _currentMaxHp = _startingMaxHp;
    }

    void changeHealthDamage(int damage)
    {
        _currentHealth += damage;

    }

    void changeMaxHealth(int mod)
    {
        _currentMaxHp += mod;
    }

    //actualiza la barra de vida visualmente
    void changeHpGauge()
    {

    }
}
