using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class LinkAttack : MonoBehaviour
{
    [SerializeField]
    private GameObject _swordHorizontal;

    [SerializeField]
    private GameObject _swordVertical;

    [SerializeField]
    private GameObject _bomb;

    [SerializeField]
    Transform _swordPos;


    /// <summary>
    /// GUARRADA ESPADA ARRROJADIZA XD
    /// </summary>

    [SerializeField]
    private GameObject _trhowingSwordRight;

    [SerializeField]
    private GameObject _trhowingSwordLeft;

    [SerializeField]
    private GameObject _trhowingSwordUp;

    [SerializeField]
    private GameObject _trhowingSwordDown;


    /// <summary>
    /// PATATA
    /// </summary>

    LinkAnimatorComponent _anim;

    [SerializeField]
    private HP_manager _hpManager;

    [SerializeField]
    private ShootingComponent _shootingComponent;

    private InventoryManager _inventoryManager;

    private BombScript _bombScript;

    private Transform _linkTransform;

    private float _offset = 1.0f;

    private Rigidbody2D _myRb;

    private Vector3 _attackDirection = Vector3.right;
    private Vector2 _oldInput = Vector2.zero;
    private Vector2 _input = Vector2.zero;
    private Vector3 _shootDirection = Vector3.right;

    private GameObject _swordInstance;
    private GameObject _bombInstance;
    private LinkController _linkController;

    private AudioManager _audioManager;
    [SerializeField] AudioClip _swordSlashAudio;
    [SerializeField] AudioClip _swordShootAudio;
    [SerializeField] AudioClip _bombDropAudio;



    private Stopwatch _sw;


    void Start()
    {
        _inventoryManager = FindAnyObjectByType<InventoryManager>();
        _linkController = GetComponent<LinkController>();
        _anim = FindAnyObjectByType<LinkAnimatorComponent>();
        _linkTransform = transform;
        _myRb = GetComponent<Rigidbody2D>();
        _shootingComponent = GetComponent<ShootingComponent>();
        _bombScript = GetComponent<BombScript>();
        _audioManager = FindObjectOfType<AudioManager>();

        _sw = new Stopwatch();

        _sw.Start();

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
        if (!_inventoryManager.itemsUnlocked[0]) return;

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
            if (_hpManager.IsFullHP() && !bomb)
            {
                if (_sw.ElapsedMilliseconds > 1500f)
                {
                    if (_oldInput.x == 1)
                    {
                        _shootDirection = Vector3.right;
                        GameObject newBullet = Instantiate(_trhowingSwordRight, _linkTransform.position + (_offset * _shootDirection), _linkTransform.rotation);
                        BulletComponent bulletComponent = newBullet.GetComponent<BulletComponent>();
                        bulletComponent.SetLinkSwordDirection(_shootDirection);
                    }

                    else if (_oldInput.x == -1)
                    {
                        _shootDirection = Vector3.left;
                        GameObject newBullet = Instantiate(_trhowingSwordLeft, _linkTransform.position + (_offset * _shootDirection), _linkTransform.rotation);
                        BulletComponent bulletComponent = newBullet.GetComponent<BulletComponent>();
                        bulletComponent.SetLinkSwordDirection(_shootDirection);
                    }

                    else if (_oldInput.y == 1)
                    {
                        _shootDirection = Vector3.up;
                        GameObject newBullet = Instantiate(_trhowingSwordUp, _linkTransform.position + (_offset * _shootDirection), _linkTransform.rotation);
                        BulletComponent bulletComponent = newBullet.GetComponent<BulletComponent>();
                        bulletComponent.SetLinkSwordDirection(_shootDirection);
                    }

                    else if (_oldInput.y == -1)
                    {
                        _shootDirection = Vector3.down;
                        GameObject newBullet = Instantiate(_trhowingSwordDown, _linkTransform.position + (_offset * _shootDirection), _linkTransform.rotation);
                        BulletComponent bulletComponent = newBullet.GetComponent<BulletComponent>();
                        bulletComponent.SetLinkSwordDirection(_shootDirection);
                    }
                    _audioManager.PlaySoundEffect(_swordShootAudio);

                    _sw.Restart();
                }
            }
            if (attacked && !bomb)
            {
                if (_oldInput.x == 1)
                {

                    _swordInstance = Instantiate(_swordHorizontal, _linkTransform.position + (_offset * _attackDirection), _linkTransform.rotation);
                }

                else if (_oldInput.x == -1)
                {

                    _swordInstance = Instantiate(_swordHorizontal, _linkTransform.position + (_offset * _attackDirection), _linkTransform.rotation);
                }

                else if (_oldInput.y == 1)
                {

                    _swordInstance = Instantiate(_swordVertical, _linkTransform.position + (_offset * _attackDirection), _linkTransform.rotation);
                }

                else if (_oldInput.y == -1)
                {

                    _swordInstance = Instantiate(_swordVertical, _linkTransform.position + (_offset * _attackDirection), _linkTransform.rotation);
                }
                _anim.UpdateAttackSword(true);
                _linkController.SetBlockMovement(true);
                _audioManager.PlaySoundEffect(_swordSlashAudio);
            }
            else if (!attacked && bomb && _inventoryManager.nBombs > 0)
            {
                _bombInstance = Instantiate(_bomb, _linkTransform.position + (_offset * _attackDirection), _linkTransform.rotation);
                _audioManager.PlaySoundEffect(_bombDropAudio);
                _inventoryManager.ChangeBombAmount(-1);
            }
        }
        else if (!attacked)
        {
            Destroy(_swordInstance);
            _linkController.SetBlockMovement(false);
            _anim.UpdateAttackSword(false);
        }
    }
}
