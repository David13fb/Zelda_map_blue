using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class BlueOctorokIA : MonoBehaviour
{
    //References:
    private CharacterMovement _chMovement;
    private Transform _myTransform;
    private ShootingComponent _shootingComponent;

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
        Vector3 rotAngle = Vector3.zero;

        if (!_parada)
        {
            switch (movement)
            {
                case 0:
                    direction = Vector2.left;
                    rotAngle.z = -90;
                    break;
                case 1:
                    direction = Vector2.right;
                    rotAngle.z = 90;
                    break;
                case 2:
                    direction = Vector2.up;
                    rotAngle.z = 180;
                    break;
                case 3:
                    direction = Vector2.down;
                    rotAngle.z = 0;
                    break;
            }
            //Only rotates if not stopping
            _myTransform.rotation = Quaternion.identity;
            _myTransform.rotation = Quaternion.Euler(rotAngle);

            _sw.Restart();
        }
        else
        {
            direction = Vector2.zero;
            if (_prevDirection != Vector2.zero) TryToShoot(); //Checks if it just stopped to shoot
        }

        //Give direction to move or stop
        _prevDirection = direction;
        _chMovement.SetCharacterVelocity(direction);
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
