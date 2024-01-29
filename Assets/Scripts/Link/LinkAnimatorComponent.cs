using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinkAnimatorComponent : MonoBehaviour
{
    [SerializeField]
    private Animator animator;
    [SerializeField]
    private Transform _transform;
     Vector3 lastposition;

    // Start is called before the first frame update
    void Start()
    {
        _transform = transform;
         lastposition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(_transform.position!= lastposition && animator != null)
        {
            animator.SetBool("moving",true);
            if (transform.position.x<lastposition.x)
            {
                animator.SetBool("xpositive", false);
            }
            else if (transform.position.x >lastposition.x)
            {
                animator.SetBool("xpositive", true);
            }
             if (transform.position.y > lastposition.y)
            {
                animator.SetBool("ypositive", true);
            }
            else if (transform.position.y < lastposition.y)
            {
                animator.SetBool("ypositive", false);
            }


        }
        lastposition = transform.position;
    }
}
