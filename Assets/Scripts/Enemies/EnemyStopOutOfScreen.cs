using UnityEngine;

public class EnemyStopOutOfScreen : MonoBehaviour
{
    private OctorokIA _OctorokMovementIA;
    private LeeverIA _LeeverMovementIA;
    private ParabolaTektiteIA _TektiteMovementIA;
    private ZolaIA _ZolaMovementIA;
    private ShootingComponent _shootingComponent;
    [SerializeField] bool _isOctorokMoblin;
    [SerializeField] bool _isLeever;
    [SerializeField] bool _isTektite;

    private bool _itsVisible = false;
    [SerializeField] bool _isZola;
    private Camera mainCamera;

    private void Awake()
    {
        if (_isOctorokMoblin)
        {
            _OctorokMovementIA = GetComponent<OctorokIA>();
            _shootingComponent = GetComponent<ShootingComponent>();
        }
        else if (_isLeever)
        {
            _LeeverMovementIA = GetComponent<LeeverIA>();
        }
        else if (_isTektite)
        {
            _TektiteMovementIA = GetComponent<ParabolaTektiteIA>();
        }
        else if (_isZola)
        {
            _ZolaMovementIA = GetComponent<ZolaIA>();
            _shootingComponent = GetComponent<ShootingComponent>();
        }
        mainCamera = Camera.main;


    }

    void Start()
    {
        if (_isOctorokMoblin)
        {
            _OctorokMovementIA.enabled = false;
            _shootingComponent.enabled = false;
            _OctorokMovementIA.StopMoving();
        }
        else if (_isLeever)
        {
            _LeeverMovementIA.enabled = false;
            _LeeverMovementIA.StopMoving();
        }
        else if (_isTektite)
        {
            _TektiteMovementIA.enabled = false;
            _TektiteMovementIA.StopMoving();
        }
        else if (_isZola)
        {
            _ZolaMovementIA.enabled = false;
            _shootingComponent.enabled = false;
            _ZolaMovementIA.StopMoving();
        }
    }

    private void Update()
    {
        bool visible = IsVisibleFromCamera();


        if (visible && !_itsVisible)
        {
            _itsVisible = true;
            if (_isOctorokMoblin)
            {
                _OctorokMovementIA.enabled = true;
                _shootingComponent.enabled = true;
                _OctorokMovementIA.StartMoving();

            }
            else if (_isLeever)
            {
                _LeeverMovementIA.enabled = true;
                _LeeverMovementIA.StartMoving();

            }
            else if (_isTektite)
            {
                _TektiteMovementIA.enabled = true;
                _TektiteMovementIA.StartMoving();

            }
            else if (_isZola)
            {
                _ZolaMovementIA.enabled = true;
                _shootingComponent.enabled = true;
                _ZolaMovementIA.StartMoving();
            }
        }
        else if(!visible && _itsVisible)
        {
            _itsVisible = false;
            if (_isOctorokMoblin)
            {
                _OctorokMovementIA.enabled = false;
                _shootingComponent.enabled = false;
                _OctorokMovementIA.StopMoving();

            }
            else if (_isLeever)
            {
                _LeeverMovementIA.enabled = false;
                _LeeverMovementIA.StopMoving();

            }
            else if (_isTektite)
            {
                _TektiteMovementIA.enabled = false;
                _TektiteMovementIA.StopMoving();

            }
            else if (_isZola)
            {
                _ZolaMovementIA.enabled = false;
                _shootingComponent.enabled = false;
                _ZolaMovementIA.StopMoving();
            }
        }
        
    }

    private bool IsVisibleFromCamera()
    {
        Vector3 screenPoint = mainCamera.WorldToViewportPoint(transform.position);

        return screenPoint.x > 0 && screenPoint.x < 1 && screenPoint.y > 0 && screenPoint.y < 1;
    }
}
