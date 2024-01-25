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
    public void Attack(bool attacked)
    {
        _sword.SetActive(attacked);
    }
} 
