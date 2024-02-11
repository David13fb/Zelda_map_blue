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
    public int _currentHealth;
    [SerializeField]
    bool _thisIsPlayer = false;
    [SerializeField]
    private HUDmanager _hudManager;
    private LinkController _linkController;
    private DropitemScrips _dropitem;

    private GameManager _gameManager;

    //Audio
    private AudioManager _audioManager;
    [SerializeField] AudioClip _linkDieAudio;
    [SerializeField] AudioClip _enemyDieAudio;

    void Start()
    {
        _linkController = FindObjectOfType<LinkController>();
        _currentHealth = _currentMaxHp = _startingMaxHp;
        _dropitem = GetComponent<DropitemScrips>();
        _gameManager = FindObjectOfType<GameManager>();
        _audioManager = FindObjectOfType<AudioManager>();
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
            _gameManager.LinkHasDied();
            _audioManager.PlaySoundEffect(_linkDieAudio);
            _audioManager.PlayOrStopMusic(false);
        }
        else
        {
            _dropitem.DropItem();
            Destroy(this.gameObject);
            _audioManager.PlaySoundEffect(_enemyDieAudio);
        }
    }

    public void deathAnimFinished()
    {
        _gameManager.DeathAnimationFinished();
    }

    public bool IsFullHP()
    {
        return _currentHealth == _currentMaxHp;
    }
}
