using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DamagingComponent : MonoBehaviour
{
    [SerializeField]
    private int _damage = 1;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        bool somethingWasHit = false;
        bool linkBlockedIt = false;

        //Damages whatever it hits if it can be damaged
        TakeDamageComponent damage = collision.gameObject.GetComponent<TakeDamageComponent>();
        if (_damage > 0)
        {
            if (damage != null)
            {
                somethingWasHit = true;
            }

            //If the object with the component is a bullet, then it destroys itself after hitting an entity
            if (somethingWasHit)
            {
                BulletComponent bulletComponent = GetComponent<BulletComponent>();
                if (bulletComponent != null)
                {
                    LinkController linkController = collision.gameObject.GetComponent<LinkController>();
                    if (linkController != null && bulletComponent.DirectionToCounter == linkController.lastInput && linkController._chMovement.NotMoving)
                    {
                        linkBlockedIt = true;
                    }

                    Destroy(gameObject);
                }
                BombScript bombScript = GetComponent<BombScript>();
                if (bombScript != null)
                {
                    LinkController linkController = collision.gameObject.GetComponent<LinkController>();


                }

                //Debug.Log(linkBlockedIt);
                if (!linkBlockedIt)
                {
                    damage.TakeDamage(_damage);
                }
            }

        }
        else
        {
            damage.TakeDamage(_damage);
            Destroy(gameObject);
        }

    }
}
