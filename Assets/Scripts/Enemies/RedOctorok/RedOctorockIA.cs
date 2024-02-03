using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class RedOctorokIA : MonoBehaviour
{
    //References:
    private CharacterMovement _chMovement;
    private Transform _myTransform;
    private ShootingComponent _shootingComponent;

    //Responsible for movement:
    private Stopwatch _sw = new Stopwatch();
    [SerializeField] private int _timerToMove = 600;

    //Responsible for shooting target movement
    [SerializeField] private Transform _targetPoint;

    
    //Responsible for shooting:
    private Stopwatch _shootingSw = new Stopwatch();
    private float _shootingTimer = 0f;
    //Time to shoot mus be in milliseconds
    [SerializeField] private float _timeToShoot1, _timeToShoot2, _timeToShoot3, _timeToShoot4;

    //Method to choose moving direction
    private void GiveRandomDirection()
    {
        int movement = Random.Range(0, 4);

        Vector2 direction = Vector2.zero;
        Vector3 newTargetOffset = Vector3.zero;

        if (movement == 0)
        {
            direction = Vector2.left;
            newTargetOffset = new Vector3(-1.5f, 0f);
        }
        else if (movement == 1)
        {
            direction = Vector2.right;
            newTargetOffset = new Vector3(1.5f, 0f);
        }
        else if (movement == 2)
        {
            direction = Vector2.up;
            newTargetOffset = new Vector3(0f, 1.5f);
        }
        else
        {
            direction = Vector2.down;
            newTargetOffset = new Vector3(0f, -1.5f);
        }
        
        _chMovement.SetCharacterVelocity(direction);
        _targetPoint.position = _myTransform.position + newTargetOffset;

        _sw.Restart();
    }

    public void StopDirection()
    {
        Vector2 direction = Vector2.zero;
        _targetPoint.position = _myTransform.position;
        _chMovement.SetCharacterVelocity(direction);
    }
    //Method to decide when to shoot
    private void CreateRandomInterval()
    {
       int random = Random.Range(0, 4);

        if (random == 0) _shootingTimer = _timeToShoot1;
        else if (random == 1) _shootingTimer = _timeToShoot2;
        else if (random == 2) _shootingTimer = _timeToShoot3;
        else _shootingTimer = _timeToShoot4;

        _shootingSw.Restart();
    }

    void Start()
    {
        _chMovement = GetComponent<CharacterMovement>();
        _shootingComponent = GetComponent<ShootingComponent>();
        _myTransform = transform;

        _sw.Start();
        _shootingSw.Start();

        CreateRandomInterval();
        GiveRandomDirection();
    }

    
    void Update()
    {
        if(_sw.ElapsedMilliseconds > _timerToMove)
        {
            GiveRandomDirection();
        }

        if(_shootingSw.ElapsedMilliseconds >= _shootingTimer) 
        {
            _shootingComponent.Shoot();
            CreateRandomInterval();
        }
    }
}
