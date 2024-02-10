using UnityEngine;

public class EnemyStopOutOfScreen : MonoBehaviour
{
    private OctorokIA _OctorokMovementIA;
    private LeeverIA _LeeverMovementIA;
    private ParabolaTektiteIA _TektiteMovementIA;
    //private ZoraIA _ZoraMovementIA;
    private ShootingComponent _shootingComponent;
    [SerializeField] bool _isOctorokMoblin;
    [SerializeField] bool _isLeever;
    [SerializeField] bool _isTektite;
    //[SerializeField] bool _isZora;
    private Camera mainCamera;

    private void Awake()
    {
        if (_isOctorokMoblin)
        {
            _OctorokMovementIA = GetComponent<OctorokIA>();
            _shootingComponent = GetComponent<ShootingComponent>();
        }
        if (_isLeever)
        {
            _LeeverMovementIA = GetComponent<LeeverIA>();
        }
        if (_isTektite)
        {
            _TektiteMovementIA = GetComponent<ParabolaTektiteIA>();
        }
        /**/
        mainCamera = Camera.main;
    }

    private void Update()
    {
        if (IsVisibleFromCamera())
        {
            if (_isOctorokMoblin)
            {
                _OctorokMovementIA.StartMoving();
                _OctorokMovementIA.enabled = true;
                _shootingComponent.enabled = true;
            }
            if (_isLeever)
            {
                _LeeverMovementIA.StartMoving();
                _LeeverMovementIA.enabled = true;
            }
            if (_isTektite)
            {
                _TektiteMovementIA.StartMoving();
                _TektiteMovementIA.enabled = true;
            }
        }
        else
        {
            if (_isOctorokMoblin)
            {
                _OctorokMovementIA.StopMoving();
                _OctorokMovementIA.enabled = false;
                _shootingComponent.enabled = false;
            }
            if (_isLeever)
            {
                _LeeverMovementIA.StopMoving();
                _LeeverMovementIA.enabled = false;
            }
            if (_isTektite)
            {
                _TektiteMovementIA.StopMoving();
                _TektiteMovementIA.enabled = false;
            }
        }
    }

    private bool IsVisibleFromCamera()
    {
        Vector3 screenPoint = mainCamera.WorldToViewportPoint(transform.position);

        return screenPoint.x > 0 && screenPoint.x < 1 && screenPoint.y > 0 && screenPoint.y < 1;
    }
}
