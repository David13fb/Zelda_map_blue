using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class OctorokIA : MonoBehaviour
{
    //References:
    private CharacterMovement _chMovement;
    private Transform _myTransform;
    private ShootingComponent _shootingComponent;
    [SerializeField] private Transform _targetPoint;

    //Timers to move and stop:
    [SerializeField] private int _timerToStop= 600;
    [SerializeField] private int _timerToMove = 1200;
    private Stopwatch _sw = new Stopwatch();
    private bool _parada = false;

    //Stores previous direction to shoot only once per stop
    private Vector2 _prevDirection;

    //Method to choose moving direction or stop
    private void GiveRandomDirection()
    {
        int movement = Random.Range(0, 4);
        Vector2 direction = Vector2.zero;
        Vector3 newShootingOffset = Vector3.zero;

        if (!_parada)
        {
            switch (movement)
            {
                case 0:
                    direction = Vector2.left;
                    newShootingOffset = new Vector3(-1.5f, 0f);
                    break;
                case 1:
                    direction = Vector2.right;
                    newShootingOffset = new Vector3(1.5f, 0f);
                    break;
                case 2:
                    direction = Vector2.up;
                    newShootingOffset =  new Vector3(0f, 1.5f);
                    break;
                case 3:
                    direction = Vector2.down;
                    newShootingOffset = new Vector3(0, -1.5f);
                    break;
            }
            _sw.Restart();
        }
        else
        {
            direction = Vector2.zero;
            if (_prevDirection != Vector2.zero) TryToShoot(); //Checks if it just stopped to shoot
        }

        //Give direction to move or stop
        _prevDirection = direction;

       // _targetPoint.position = _myTransform.position + newShootingOffset;
        _chMovement.SetCharacterVelocity(direction);
    }

    //Method to stop moving when out of the screen. Also stops the timer so it does not shoot
    public void StopMoving()
    {
        _sw.Stop();
        Vector2 direction = Vector2.zero;
       // _targetPoint.position = _myTransform.position;
        _chMovement.SetCharacterVelocity(direction);
    }
    public void StartMoving()
    {
        _sw.Start();
    }

    //Method to shoot
    private void TryToShoot()
    {
        if (Random.Range(0, 4) == 0) _shootingComponent.Shoot();
    }

    void Start()
    {
        _chMovement = GetComponent<CharacterMovement>();
        _myTransform = transform;
        _shootingComponent = GetComponent<ShootingComponent>();

        _sw.Start();

        GiveRandomDirection();
    }


    void Update()
    {
        
        if (_sw.ElapsedMilliseconds > _timerToMove)
        {
            _parada = false;
            GiveRandomDirection();
        }
        else if (_sw.ElapsedMilliseconds > _timerToStop)
        {
            _parada = true;
            GiveRandomDirection();
        }
    }
}
