using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class RedOctorok_IA_Movement : MonoBehaviour
{

    private CharacterMovement _chMovement;

    private int _movement = 0;

    private int _timer = 600;

    private Stopwatch _sw = new Stopwatch();


    private void GiveRandomDirection()
    {
        _movement = Random.Range(0, 3);

        if (_movement == 0)
            _chMovement.SetCharacterVelocity(Vector2.left);
        else if (_movement == 1)
            _chMovement.SetCharacterVelocity(Vector2.right);
        else if ( _movement == 2)
            _chMovement.SetCharacterVelocity(Vector2.up);
        else
            _chMovement.SetCharacterVelocity(Vector2.down);

        _sw.Restart();

    }

    void Start()
    {
        _chMovement = GetComponent<CharacterMovement>();
        _sw.Start();
        GiveRandomDirection();
    }

    
    void Update()
    {
        if(_sw.ElapsedMilliseconds > _timer)
        {
            GiveRandomDirection();
        }
    }
}
