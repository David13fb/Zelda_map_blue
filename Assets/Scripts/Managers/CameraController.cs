using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{ 
    // This will be used to store the GameManager reference
    private GameManager _gameManager; 

    // This will be used to check if the camera is transitioning
    private bool _isTransitioning = false; 

    // This will be used to access the camera's transform
    private Transform _myTransform; 

    // Singleton pattern
    public static CameraController instance;
    
    // Singleton pattern
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Setting the references
    void Start()
    {
        _myTransform = transform;
        _gameManager = GameManager.instance;
        _isTransitioning = false;
    }

    // This method will be called by the GameManager to transition the camera to a new screen
    // It calls a coroutine to move the camera smoothly
    public void TransitionToScreen(int targetX, int targetY, float transitionDuration)
    {
        if (!_isTransitioning)
        {
            StartCoroutine(MoveCameraToScreen(targetX, targetY, transitionDuration));
        }
    }

    // This coroutine will move the camera smoothly to the target screen
    IEnumerator MoveCameraToScreen(int targetX, int targetY, float duration)
    {
        _isTransitioning = true;
        
        // Formula of new position: (targetScreenCoordinate * screenSize) + (screenSize / 2)
        // Because we need to put it in the center of the screen, we need to add half of the screen size
        // In case of the Y coordinate, we also need to add the vertical offset (to account for UI elements)
        Vector3 startPosition = _myTransform.position;
        Vector3 targetPosition = new Vector3(targetX * _gameManager.screenSizeWidth + _gameManager.screenSizeWidth /2, targetY * _gameManager.screenSizeHeight + _gameManager.screenSizeHeight/2 + _gameManager.verticalScreenOffset, _myTransform.position.z);

        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            _myTransform.position = Vector3.Lerp(startPosition, targetPosition, elapsedTime / duration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        _myTransform.position = targetPosition;
        _isTransitioning = false;
    }
}
