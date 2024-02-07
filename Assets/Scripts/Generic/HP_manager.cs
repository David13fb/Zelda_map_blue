using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HP_manager : MonoBehaviour
{
    public int CurrentHealth { get { return _currentHealth; } } 

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
    private LinkController _linkController;

    void Start()
    {
        _linkController = FindObjectOfType<LinkController>();
        _currentHealth = _currentMaxHp = _startingMaxHp;
        if (_thisIsPlayer)
            changeHpGauge();
    }

    public void changeCurrentHealth(int damage)
    {

        _currentHealth += damage;
        if(_currentHealth > _currentMaxHp)
            _currentHealth = _currentMaxHp;
        

        if (_thisIsPlayer)
            changeHpGauge();

        if (_currentHealth <= 0)
        {
            Die();
        }

    }

    public void changeMaxHealth(int mod)
    {
        _currentMaxHp += mod;
        if (_thisIsPlayer)
            changeHpGauge();
    }

    //actualiza la barra de vida visualmente
    public void changeHpGauge()
    {
        _hudManager.UpdateCurrentHP(_currentHealth);
        _hudManager.UpdateHPmaxHP(_currentMaxHp);
    }

    private void Die()
    {
        if (_thisIsPlayer)
        {
            GameManager.instance.LinkHasDied();
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    public void deathAnimFinished()
    {
        GameManager.instance.DeathAnimationFinished();
    }

    public bool IsFullHP()
    {
        return _currentHealth == _currentMaxHp;
    }
}
