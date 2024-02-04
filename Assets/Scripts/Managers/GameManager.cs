using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool linkOnCave;
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
    private LinkController _characterController;
    private ChangeToRedDeadScreen _changeRedScreen;
    private LinkAnimatorComponent _linkAnimatorComponent;

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
        _hudmanager = FindObjectOfType<HUDmanager>();
        _cameraController = CameraController.instance;
        screenSizeHeight = Camera.main.orthographicSize * 2 * 0.7f;
        screenSizeWidth = Camera.main.orthographicSize * 2 * Camera.main.aspect;
        _changeRedScreen = FindAnyObjectByType<ChangeToRedDeadScreen>();
        _characterController = FindAnyObjectByType<LinkController>();
        cam = Camera.main;
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

    public void LinkHasDied()
    {
        _changeRedScreen.SetDeathScreenColorChange();
        Time.timeScale = 0;
    }

    public void DeathAnimationFinished()
    {
        _characterController.DisableLink();
        _changeRedScreen.SpawnLoseGame();
    }

    public void PickItem(int item)
    {
        _linkAnimatorComponent.ItemPicked(item);
    }
}
