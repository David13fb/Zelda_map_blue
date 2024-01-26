using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    
    // This defines the size of the screen in world units
    [HideInInspector] public float screenSizeWidth, screenSizeHeight;

    // This defines the vertical offset of the screen in world units (to account for UI elements)
    [SerializeField] public float verticalScreenOffset;

    // These variables will be used to store the current screen coordinates
    public int currentScreenX, currentScreenY;

    // These variables will be used to store the previous screen coordinates
    private int previousScreenX, previousScreenY;

    // Singleton pattern
    public static GameManager instance;
    
    // This will be used to access the CameraController
    private CameraController _cameraController;
    
    // Singleton pattern
    void Awake()
    {
        // Singleton pattern
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

    // Reference to the CameraController and setting the screen size
    void Start()
    {
        _cameraController = CameraController.instance;
        screenSizeHeight = Camera.main.orthographicSize * 2 * 0.7f;
        screenSizeWidth = Camera.main.orthographicSize * 2 * Camera.main.aspect;
    }


    void Update()
    {
        // This will check if the player has moved to a new screen
        if ((previousScreenX != currentScreenX) || (previousScreenY != currentScreenY))
        {
            previousScreenX = currentScreenX;
            previousScreenY = currentScreenY;
            Debug.Log("Screen changed to " + currentScreenX + ", " + currentScreenY);
            _cameraController.TransitionToScreen(currentScreenX, currentScreenY, 1f);
            // TODO: Call method in LinkController to freeze character during transition
        }
    }
}
