using UnityEngine;

public class EnemyStopOutOfScreen : MonoBehaviour
{
    private BlueOctorokIA _enemyMovementIA;
    private RedOctorokIA _enemyMovementIA2;
    private ShootingComponent _shootingComponent;
    private Camera mainCamera;

    private void Awake()
    {
        _enemyMovementIA = GetComponent<BlueOctorokIA>();
        //_enemyMovementIA2 = GetComponent<RedOctorokIA>();
        _shootingComponent = GetComponent<ShootingComponent>();
        mainCamera = Camera.main;
    }

    private void Update()
    {
        if (IsVisibleFromCamera())
        {
            _enemyMovementIA.enabled = true;
            //_enemyMovementIA2.enabled = true;
            _shootingComponent.enabled = true;
        }
        else
        {
            _enemyMovementIA.StopDirection();
            _enemyMovementIA.enabled = false;
            //_enemyMovementIA2.StopDirection();
            //_enemyMovementIA2.enabled = false;
            _shootingComponent.enabled = false;
        }
    }

    private bool IsVisibleFromCamera()
    {
        Vector3 screenPoint = mainCamera.WorldToViewportPoint(transform.position);

        return screenPoint.x > 0 && screenPoint.x < 1 && screenPoint.y > 0 && screenPoint.y < 1;
    }
}
