using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeeverIA : MonoBehaviour
{
    //References:
    private CharacterMovement _chMovement;
    private Collider2D _collider;
    private Transform _myTransform;
    [SerializeField] private Transform _playerTransform;
    [SerializeField] private LeeverAnimator _animator;

    private float _timer;

    //Timers to move and stop:
    [SerializeField] private float _timerToStop = 5.5f;
    [SerializeField] private float _timerToSpawn = 0.5f;

    private bool _outOfScreen = false;
    //private Stopwatch _sw = new Stopwatch();
    private float _yPosition;

    enum State
    {
        spawn,
        dissapear,
        resetting
    }

    private State _currentState;

    
    //Methods to start/stop moving when in/out of the screen.
    public void StopMoving()
    {
        Vector2 direction = Vector2.zero;
        _outOfScreen = true;
    }
    public void StartMoving()
    {
        _outOfScreen = false;
        SpawnAndDirection();
        _currentState = State.resetting;
        _timer = Time.time;
    }

    void SpawnAndDirection()
    {
        _collider.enabled = true;
        int _spawnPosition = Random.Range(0, 2);
        Vector2 direction = Vector2.zero;
        float _offset =3f;

        if (_spawnPosition == 0)
        {
            _myTransform.position = new Vector3(_playerTransform.position.x + (_offset * -1), _yPosition, 0);
            direction = Vector2.right;
        }
        else
        {
            _myTransform.position = new Vector3(_playerTransform.position.x + (_offset), _yPosition, 0);
            direction = Vector2.left;
        }

        _chMovement.SetCharacterVelocity(direction);
    }

    void Disappear()
    {
        Vector2 direction = Vector2.right;
        _chMovement.SetCharacterVelocity(Vector3.zero);
        _collider.enabled = false;
    }

    void Start()
    {
        _chMovement = GetComponent<CharacterMovement>();
        _animator = GetComponent<LeeverAnimator>();
        _myTransform = transform;
        _yPosition = _myTransform.position.y;
        _collider = GetComponent<Collider2D>();


        _timer = Time.time;
        _currentState = State.resetting;

        
    }


    void Update()
    {
        if (_outOfScreen) return;

        if (Time.time - _timer >= _timerToStop + _timerToSpawn)
        {
            if (_currentState != State.resetting)
            {
                _timer = Time.time;
                _currentState = State.resetting;
            }
        }
        else if (Time.time - _timer >= _timerToStop)
        {
            if(_currentState != State.dissapear) 
            {
                _animator.Stopped();
                _currentState = State.dissapear;
                Disappear();
            }
        }
        else if (Time.time - _timer >= _timerToSpawn)
        {
            if(_currentState != State.spawn)
            {
                _currentState = State.spawn;

                SpawnAndDirection();
            }
        }
        
    }
}
