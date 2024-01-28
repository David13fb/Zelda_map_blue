using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using UnityEngine;



public class TakeDamageComponent : MonoBehaviour
{
    //references
    HP_manager _hpManager;
    Rigidbody2D _rb;            
    SpriteRenderer _spriteRenderer;
    [SerializeField]Transform _linkTransform; //taken to push everything in links looking direction
   
    //parameters
    private Vector3 _pushDirection;
    [SerializeField]
    private int _colorQuantity = 0;
    private int _loopIterations = 0;

    // Comented code is a invul system

    //private Stopwatch _stopwatch = new Stopwatch();
    //[SerializeField] private float _invulMiliseconds = 1000f;

    //methods
    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _hpManager = GetComponent<HP_manager>();
        //_stopwatch.Start();
    
    }
    public void TakeDamage(int damage) 
    { 
        //if(_stopwatch.ElapsedMilliseconds > _invulMiliseconds) 
        //{
            if (_hpManager != null && _spriteRenderer != null && _rb != null)
            {
                _hpManager.changeCurrentHealth(-damage); //damage taken is a negative, damage is a positive value
                _loopIterations = _colorQuantity;
                ColorLoop();
                _pushDirection = -_linkTransform.up;
                _rb.AddForce(_pushDirection);
            }
        //    _stopwatch.Restart();
        //}
    }

    void ColorLoop()
    {
        
     
        _spriteRenderer.color = Random.ColorHSV();
           
        _spriteRenderer.color = UnityEngine.Color.white;
    }

   
    

}
