using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZolaAnimator : MonoBehaviour
{
    [SerializeField] private Animator _animator;

    private bool shoot;
    private void Start()
    {
        _animator = GetComponent<Animator>();

        StartCoroutine(Move());

    }

    public void Shoot(bool newState)
    {
        shoot = newState;
    }

    private IEnumerator Move()
    {
      

        while (true)
        {
            // Animación "down"
            _animator.SetBool("Water", true);
            yield return new WaitForSeconds(0.6f);

            // Animación "up"
            _animator.SetBool("Water", false);
            yield return new WaitForSeconds(0.6f);


            if (shoot)
            {

                _animator.SetBool("Shoot", true);
                yield return new WaitForSeconds(0.6f);
                _animator.SetBool("Shoot", false);



            }
        }
    }

}
