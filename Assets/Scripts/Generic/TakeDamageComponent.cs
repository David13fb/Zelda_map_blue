using System.Collections;
using System.Collections.Generic;
//using System.Diagnostics;
//using System.Drawing;
using UnityEngine;



public class TakeDamageComponent : MonoBehaviour
{
    //references
    HP_manager _hpManager;
    Rigidbody2D _rb;            
    SpriteRenderer _spriteRenderer;
    [SerializeField]Transform _linkTransform; //taken to push everything in links looking direction
   
    //getting pushed related parameters:
    private Vector2 _pushDirection;
    private Color[] sequenceOfColors = new Color[] { Color.white, Color.red, Color.blue, Color.green};

    private bool _colorLoopEnabled;
    private static float _singleColorDuration = 0.1f;
    [SerializeField] private int _currentColorCount = 0;
    private float _timer = 0;


    // Comented code is a invul system

    //private Stopwatch _stopwatch = new Stopwatch();
    //[SerializeField] private float _invulMiliseconds = 1000f;

    //methods
    private void Start()
    {
        _linkTransform = FindObjectOfType<LinkController>().transform;
        _rb = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _hpManager = GetComponent<HP_manager>();
        //_stopwatch.Start();
    
    }
    public void TakeDamage(int damage) 
    { 
            if (_hpManager != null && _spriteRenderer != null && _rb != null && !_colorLoopEnabled)
            {
                _hpManager.changeCurrentHealth(-damage); //damage taken is a negative, damage is a positive value
                ColorLoop();
                _pushDirection = -_linkTransform.up;
                _rb.MovePosition(_rb.position + _pushDirection);
            }
    }

    private void Update()
    {
        if (_colorLoopEnabled && _hpManager.CurrentHealth != 0)
        {
            if (Time.unscaledTime - _timer > _singleColorDuration)
            {
                if (_currentColorCount % 12 == 11)
                {
                    _colorLoopEnabled = false;
                    _spriteRenderer.color = Color.white;
                }
                else
                {
                    _spriteRenderer.color = sequenceOfColors[_currentColorCount % sequenceOfColors.Length];
                    _timer = Time.unscaledTime;
                }
                _currentColorCount++;
            }

        }
    }

    private void ColorLoop()
    {
        _colorLoopEnabled = true;
        _timer = Time.unscaledTime;        
    }
}
