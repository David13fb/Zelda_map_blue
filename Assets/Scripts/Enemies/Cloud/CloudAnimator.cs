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
    [SerializeField] private GameObject _enemy;

    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _animator = GetComponent<Animator>();
        
        StartCoroutine(CloudAppear());
        _enemy.SetActive(false);
    }
    IEnumerator CloudAppear()
    {
        _animator.SetBool("Cloud", false);
        yield return new WaitForSeconds(_time);
        _animator.SetBool("Cloud", true);
        yield return new WaitForSeconds(_time);

        // call to set inactive the sprite
        gameObject.SetActive(false);
        _enemy.SetActive(true);
       


    }
}
