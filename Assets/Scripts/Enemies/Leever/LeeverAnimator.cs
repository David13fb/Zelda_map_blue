using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeeverAnimator : MonoBehaviour
{
    [SerializeField]
    private Animator _animator;
  

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
            _animator.SetBool("Rot", true);
            yield return new WaitForSeconds(0.3f);
            _animator.SetBool("Rot", false);
            yield return new WaitForSeconds(0.3f);
        }
      




    }
}
