using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class ZolaIA : MonoBehaviour
{
    //References:
    private ZolaAnimator _zolaAnimator;
    private Collider2D _collider;
    private Transform _myTransform;
    private ShootingComponent _shootingComponent;

    [SerializeField] private Transform _lakeCentre;
    [SerializeField] private float _lakeWidth;
    [SerializeField] private float _lakeHeight;
    [SerializeField] private Transform _playerTransform;

    //Responsible for shooting:
    private Stopwatch _shootingSw = new Stopwatch();
    [SerializeField] private float _timeToShoot;

    private float _timer;
    private bool _outOfScreen;

    [SerializeField] private bool _InACorner;
    [SerializeField] private Transform _notAllowedCentre;
    [SerializeField] private float _notAllowedWidth;
    [SerializeField] private float _notAllowedHeight;

    //Timers to move and stop:
    [SerializeField] private float _timerToStop = 5.5f;
    [SerializeField] private float _timerToSpawn = 0.5f;

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
        _outOfScreen = true;
    }
    public void StartMoving()
    {

        _outOfScreen = false;
    }

    void SpawnAndDirection()
    {
        _collider.enabled = true;
        if (_InACorner)
        {
            float _xCoord;
            float _yCoord;
            do
            {
                _xCoord = Random.Range(-_lakeWidth, _lakeWidth);
                _yCoord = Random.Range(-_lakeHeight, _lakeHeight);
            } while (_xCoord > (_notAllowedCentre.position.x + _notAllowedWidth) && _xCoord < (_notAllowedCentre.position.x - _notAllowedWidth) && _yCoord > (_notAllowedCentre.position.y + _notAllowedHeight) && _yCoord < (_notAllowedCentre.position.y - _notAllowedWidth));

            Vector3 newPosition = new Vector3(_xCoord, _yCoord, 0);
            _myTransform.position = _lakeCentre.position + newPosition;
        }
        else
        {
            Vector3 newPosition = new Vector3(Random.Range(-_lakeWidth, _lakeWidth), Random.Range(-_lakeHeight, _lakeHeight), 0);
            _myTransform.position = _lakeCentre.position + newPosition;
        }
    }

    void Start()
    {
        _zolaAnimator = GetComponent<ZolaAnimator>();
        _myTransform = transform;
        _collider = GetComponent<Collider2D>();
        _shootingComponent = GetComponent<ShootingComponent>();
        _timer = Time.time;

        _currentState = State.resetting;
    }


    void Update()
    {
        //_timer += Time.deltaTime;
        if (Time.time - _timer >= _timerToStop + _timerToSpawn && !_outOfScreen)
        {
            if (_currentState != State.resetting)
            {
                _timer = Time.time;
                _currentState = State.resetting;
                SpawnAndDirection();
            }
        }
        else if (Time.time - _timer >= _timerToStop && !_outOfScreen)
        {
            if (_currentState != State.dissapear)
            {
                _currentState = State.dissapear;
                _collider.enabled = false;
            }
        }
        else if (Time.time - _timer >= _timerToSpawn && !_outOfScreen)
        {
            if (_currentState != State.spawn)
            {
                _currentState = State.spawn;
                _shootingSw.Restart();
            }
        }
        if (_shootingSw.ElapsedMilliseconds >= _timeToShoot && !_outOfScreen)
        {
            _shootingComponent.Shoot();
            _shootingSw.Stop();
        }

    }
}

