using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudAnimator : MonoBehaviour
{
    [SerializeField]
    private Animator _animator;
    [SerializeField]
    private SpriteRenderer _spriteRenderer;
    [SerializeField]
    private float _time;

    private void Start()
    {

        _animator = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
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
        
       


    }
}
