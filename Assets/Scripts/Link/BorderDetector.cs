using UnityEngine;
using System;

public class BorderDetector : MonoBehaviour
{

    // This will be used to access the player's transform
    private Transform _playerTransform;

    // This will be used to access the GameManager
    private GameManager _gameManager;

    // This will be used to access the CameraController
    private CameraController _cameraController;

    
    // Setting all the references
    void Start()
    {
        _playerTransform = transform;
        _gameManager = GameManager.instance;
        _cameraController = CameraController.instance;
    }

    // This method checks the player's position and updates the current screen coordinates
    void Update()
    {
        Vector3 playerPosition = _playerTransform.position;
        _gameManager.currentScreenX = Mathf.FloorToInt(playerPosition.x / _gameManager.screenSizeWidth);
        _gameManager.currentScreenY = Mathf.FloorToInt(playerPosition.y / _gameManager.screenSizeHeight);
    }
}
