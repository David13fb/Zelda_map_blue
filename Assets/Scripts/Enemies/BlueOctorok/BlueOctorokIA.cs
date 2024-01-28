using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class BlueOctorokIA : MonoBehaviour
{

    private CharacterMovement _chMovement;
    private Transform _myTransform;

    private int _movement = 0;

    [SerializeField] private int _timerToStop= 600;
    [SerializeField] private int _timerToMove = 1200;

    private Stopwatch _sw = new Stopwatch();

    private bool _parada = false;
    private void GiveRandomDirection()
    {
        _movement = Random.Range(0, 4);
        Vector2 direction = Vector2.zero;
        Vector3 rotAngle = Vector3.zero;

        if (!_parada)
        {
            switch (_movement)
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
            _sw.Restart();
        }
        else
        {
            direction = Vector2.zero;
        }

        _chMovement.SetCharacterVelocity(direction);

        _myTransform.rotation = Quaternion.identity;
        _myTransform.rotation = Quaternion.Euler(rotAngle);

        /*if (_movement == 0)
            _chMovement.SetCharacterVelocity(Vector2.left);
        else if (_movement == 1)
            _chMovement.SetCharacterVelocity(Vector2.right);
        else if (_movement == 2)
            _chMovement.SetCharacterVelocity(Vector2.up);
        else
            _chMovement.SetCharacterVelocity(Vector2.down);
        */


    }

    void Start()
    {
        _chMovement = GetComponent<CharacterMovement>();
        _myTransform = transform;
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
