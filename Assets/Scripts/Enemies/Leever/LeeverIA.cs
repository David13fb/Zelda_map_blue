using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using TMPro;
using UnityEngine;

public class LeeverIA : MonoBehaviour
{
    //References:
    private CharacterMovement _chMovement;
    private Transform _myTransform;
    [SerializeField] private Transform _playerTransform;

    //Timers to move and stop:
    [SerializeField] private int _timerToStop = 5500;
    [SerializeField] private int _timerToSpawn = 500;
    private Stopwatch _sw = new Stopwatch();

    //Methods to start/stop moving when in/out of the screen.
    public void StopMoving()
    {
        _sw.Stop();
        Vector2 direction = Vector2.zero;
        _chMovement.SetCharacterVelocity(direction);
    }
    public void StartMoving()
    {
        SpawnAndDirection();
        _sw.Start();
    }

    void SpawnAndDirection()
    {
        int _spawnPosition = Random.Range(0, 2);
        Vector2 direction = Vector2.zero;
        Vector3 _offset = new Vector3 (3, 0, 0);

        if (_spawnPosition == 0)
        {
            _myTransform.position = _playerTransform.position + (_offset * -1);
            direction = Vector2.left;
        }
        if (_spawnPosition == 1)
        {
            _myTransform.position = _myTransform.position + (_offset);
            direction = Vector2.right;
        }

        _chMovement.SetCharacterVelocity(direction);
    }

    void Disappear()
    {
        Vector2 direction = Vector2.right;
        _chMovement.SetCharacterVelocity(direction);
    }

    void Start()
    {
        _chMovement = GetComponent<CharacterMovement>();
        _myTransform = transform;

        _sw.Start();

        
    }


    void Update()
    {
        if (_sw.ElapsedMilliseconds == _timerToSpawn)
        {
            SpawnAndDirection();
        }
        if (_sw.ElapsedMilliseconds == _timerToStop)
        {
            Disappear();
        }
        if (_sw.ElapsedMilliseconds == _timerToStop + _timerToSpawn)
        {
            _sw.Restart();
        }
        
    }
}
