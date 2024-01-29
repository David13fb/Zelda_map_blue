using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnForAnimator : MonoBehaviour
{
    Transform _myTransform;

    void Start()
    {
        _myTransform = transform;
    }


    public void Turn()
    {
        _myTransform.localScale = new Vector3(-1 * _myTransform.localScale.x, _myTransform.localScale.y, _myTransform.localScale.z);
    }
}
