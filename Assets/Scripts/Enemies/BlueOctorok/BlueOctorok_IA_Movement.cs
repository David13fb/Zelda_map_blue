using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class BlueOctorok_IA_Movement : MonoBehaviour
{

    private CharacterMovement _chMovement;

    private int _movement = 0;

    private int _timerToStop= 600;
    private int _timer = 1200;

    private Stopwatch _sw = new Stopwatch();

    private bool _parada = false;
    private void GiveRandomDirection()
    {
        _movement = Random.Range(0, 4);


        if (!_parada)
        {
            switch (_movement)
            {
                case 0:
                    _chMovement.SetCharacterVelocity(Vector2.left);
                    break;
                case 1:
                    _chMovement.SetCharacterVelocity(Vector2.right);
                    break;
                case 2:
                    _chMovement.SetCharacterVelocity(Vector2.up);
                    break;
                case 3:
                    _chMovement.SetCharacterVelocity(Vector2.down);
                    break;
            }
            _sw.Restart();
        }
        else
        {
            _chMovement.SetCharacterVelocity(Vector2.zero);
        }

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
        _sw.Start();
        GiveRandomDirection();
    }


    void Update()
    {
        
        if (_sw.ElapsedMilliseconds > _timer)
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
