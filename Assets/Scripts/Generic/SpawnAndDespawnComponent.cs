using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnAndDespawnComponent : MonoBehaviour
{
    private void OnWillRenderObject()
    {
        gameObject.SetActive(true);
    }

    private void OnBecameInvisible()
    {
        gameObject.SetActive(false);
    }
}
