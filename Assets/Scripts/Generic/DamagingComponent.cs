using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagingComponent : MonoBehaviour
{
    [SerializeField]
    private int _damage = 1;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        bool somethingWasHit = false;

        //Damages whatever it hits if it can be damaged
        TakeDamageComponent damage = collision.gameObject.GetComponent<TakeDamageComponent>();
        if (damage != null)
        {
            damage.TakeDamage(_damage);
            somethingWasHit = true;
        }

        //If the object with the component is a bullet, then it destroys itself after hitting an entity
        if (somethingWasHit)
        {
            BulletComponent bulletComponent = GetComponent<BulletComponent>();
            if (bulletComponent != null)
            {
                Destroy(gameObject);
            }
        }
        
    }
}
