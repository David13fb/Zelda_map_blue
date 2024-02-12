using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]

    private int _frameRate = 60;

    public bool linkOnCave;
    // This will be used to check if the player is dead
    public bool isDead;
    Vector2 direc;
    [SerializeField]
    private Camera cam;
    private HUDmanager _hudmanager;
    
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

    // This will be used to access the LinkController
    public LinkController _characterController;
    private LevelManager _levelManager;
    private ChangeToRedDeadScreen _changeRedScreen;
    private LinkAnimatorComponent _linkAnimatorComponent;

    

    // Reference to the CameraController and setting the screen size
    void Start()
    {
       
            // Switch to 640 x 480 full-screen
            Screen.SetResolution(640, 480, true);
        
        _hudmanager = FindObjectOfType<HUDmanager>();
        _cameraController = FindAnyObjectByType<CameraController>();
        screenSizeHeight = Camera.main.orthographicSize * 2 * 0.7f;
        screenSizeWidth = Camera.main.orthographicSize * 2 * Camera.main.aspect;
        _changeRedScreen = FindAnyObjectByType<ChangeToRedDeadScreen>();
        _characterController = FindAnyObjectByType<LinkController>();
        _linkAnimatorComponent = FindObjectOfType<LinkAnimatorComponent>();
        _levelManager = FindObjectOfType<LevelManager>();
        
        cam = Camera.main;

        Application.targetFrameRate = _frameRate;
    }

    


    async void Update() 
    {
        if (linkOnCave) return;

        // This will check if the player has moved to a new screen
        if ((previousScreenX != currentScreenX) || (previousScreenY != currentScreenY))
        {
            previousScreenX = currentScreenX;
            previousScreenY = currentScreenY;
            //Debug.Log("Screen changed to " + currentScreenX + ", " + currentScreenY);
            _cameraController.TransitionToScreen(currentScreenX, currentScreenY, 1f);
            await _characterController.FreezeCharacter(1f);

            //Call to updateMiniMap as scene has changed
            //declarar lo que vale direc, nose como hacerlo
                _hudmanager.UpdateMinimap(true, Camera.main.transform.position);
            
            
         
        }
      //  Debug.Log(cam.transform.position);
    }

    async public void LinkHasDied()
    {
       
        _changeRedScreen.SetDeathScreenColorChange();
        _linkAnimatorComponent.LinkIsDead();
        await _characterController.FreezeCharacter(3f);
    }

    public void DeathAnimationFinished()
    {
        _characterController.DisableLink();
        _changeRedScreen.SpawnLoseGame();
        isDead = true;
    }
}

