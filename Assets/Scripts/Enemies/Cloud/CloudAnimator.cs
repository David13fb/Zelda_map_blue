using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudAnimator : MonoBehaviour
{
    [SerializeField]
    private Animator _animator;
    [SerializeField]
    private SpriteRenderer _spriteRenderer;
  
    private float _time=0.4f;
   
    [SerializeField] 
    private ParabolaTektiteIA _parabola;


    private void Awake()
    {
        gameObject.SetActive(false);
       
    }
    private void Start()
    {
        
        
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _animator = GetComponent<Animator>();
       
        
    }

    public void Activate(bool state)
    {
            gameObject.SetActive(state);
        StartCoroutine(CloudAppear());
    }



    IEnumerator CloudAppear()
    {
        _animator.SetBool("Cloud", false);
        yield return new WaitForSeconds(_time);
        _animator.SetBool("Cloud", true);
        yield return new WaitForSeconds(_time);

        // call to set inactive the sprite
        gameObject.SetActive(false);
        _parabola.Active(true);

       
       


    }
}
