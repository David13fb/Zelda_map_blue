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

    public void Shoot()
    {
        shoot= true;
    }



    private IEnumerator Move()
    {

        while (true)
        {

            if (shoot)
            {

                _animator.SetTrigger("Shoot");
                yield return new WaitForSeconds(0.5f);
                _animator.SetBool("Water", true);
                shoot = false;


            }
            
            

                // Animación "down"
                _animator.SetBool("Water", true);
                if (!shoot) yield return new WaitForSeconds(0.1f);

                // Animación "up"
                _animator.SetBool("Water", false);
                if (!shoot) yield return new WaitForSeconds(0.1f);



            
        }
    }

}
