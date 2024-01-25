using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class LinkAttack : MonoBehaviour
{
    [SerializeField]
    private GameObject _sword;
    private Stopwatch _stopwatch;
    [SerializeField]
    private float _attackMiliSeconds = 250f;
    public void Attack()
    {
        _sword.SetActive(true);
        _stopwatch.Restart();
    }
    public void TakeSwordAway()
    {
        if (_stopwatch.ElapsedMilliseconds >= _attackMiliSeconds)
        _sword.SetActive(false);
    }
    private void Update()
    {
        TakeSwordAway();
    }
} 
