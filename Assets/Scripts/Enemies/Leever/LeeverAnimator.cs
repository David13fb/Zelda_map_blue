using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeeverAnimator : MonoBehaviour
{
    [SerializeField]
    private Animator _animator;

    private bool _stop = false;
    private bool _firstTime = true;

    private void Start()
    {

        _animator = GetComponent<Animator>();
        StartCoroutine(Leever());

    }

    private void Awake()
    {
        gameObject.SetActive(false);

    }

    public void Activate(bool state)
    {
        gameObject.SetActive(state);
    }




    IEnumerator Leever()
    {
        if (!_firstTime) yield return new WaitForSeconds(3.8f);
        _animator.SetBool("Dirt", true);
        yield return new WaitForSeconds(0.3f);
        _animator.SetBool("Dirt", false);
        yield return new WaitForSeconds(0.3f);
        _animator.SetBool("Emerge", true);
        yield return new WaitForSeconds(0.3f);
        StartCoroutine(Rotation());



    }
    IEnumerator Rotation()
    {
        while (true) 
        {
            _firstTime = false;
            _animator.SetBool("Rot", true);
            if (!_stop) yield return new WaitForSeconds(0.3f);
            _animator.SetBool("Rot", false);
            if(!_stop)yield return new WaitForSeconds(0.3f);

            if (_stop)
            {
                _animator.SetTrigger("Stop");
                _animator.SetBool("Dirt", false);
                _animator.SetBool("Emerge", false);
                _stop = false;
                break;
            }
        }
        StartCoroutine(Leever());





    }

    public void Stopped()
    {
        _stop = true;
    }
}
