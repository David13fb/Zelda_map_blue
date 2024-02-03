using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnAndDespawnComponent : MonoBehaviour
{
    RedOctorokIA _movementIA;
    ShootingComponent _shootingComponent;

    private void Awake()
    {
        _movementIA = GetComponent<RedOctorokIA>();
        _shootingComponent = GetComponent<ShootingComponent>();
        _movementIA.enabled = false;
        _shootingComponent.enabled = false;
    }
    private void OnBecameVisible()
    {
        _movementIA.enabled = true;
        _shootingComponent.enabled = true;
    }

    private void OnBecameInvisible()
    {
        _movementIA.enabled = false;
        _shootingComponent.enabled = false;
    }
}
