using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class RedOctorokIA : MonoBehaviour
{

    private CharacterMovement _chMovement;
    private Transform _myTransform;
    private ShootingComponent _shootingComponent;

    private int _movement = 0;

    [SerializeField] private int _timerToMove = 600;

    private Stopwatch _sw = new Stopwatch();


    private void GiveRandomDirection()
    {
        _movement = Random.Range(0, 4);

        Vector2 direction = Vector2.zero;
        Vector3 rotAngle = Vector3.zero;

        if (_movement == 0)
        {
            direction = Vector2.left;
            rotAngle.z = -90;
        }
        else if (_movement == 1)
        {
            direction = Vector2.right;
            rotAngle.z = 90;
        }
        else if (_movement == 2)
        {
            direction = Vector2.up;
            rotAngle.z = 180;
        }
        else
        {
            direction = Vector2.down;
            rotAngle.z = 0;
        }
        
        _chMovement.SetCharacterVelocity(direction);

        _myTransform.rotation = Quaternion.identity;
        _myTransform.rotation = Quaternion.Euler(rotAngle);

        _sw.Restart();
    }

    void Start()
    {
        _chMovement = GetComponent<CharacterMovement>();
        _shootingComponent = GetComponent<ShootingComponent>();
        _myTransform = transform;
        _sw.Start();
        GiveRandomDirection();
    }

    
    void Update()
    {
        if(_sw.ElapsedMilliseconds > _timerToMove)
        {
            GiveRandomDirection();
        }
        
    }
}
