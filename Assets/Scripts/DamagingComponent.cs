using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagingComponent : MonoBehaviour
{
    [SerializeField]
    private int _damage = 1;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        TakeDamageComponent damage = collision.gameObject.GetComponent<TakeDamageComponent>();
        if (damage != null)
        {
            damage.TakeDamage(_damage);
        }
    }
}
