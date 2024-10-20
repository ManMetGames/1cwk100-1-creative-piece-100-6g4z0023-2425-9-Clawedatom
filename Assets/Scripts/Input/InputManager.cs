using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    #region Class References
    private static InputManager _instance;

    PlayerControls playerControls;
    PlayerManager playerManager;


    PlayerUIManager playerUIManager;
    #endregion

    #region Private Fields
    [Header("Player Inputs")]
    [SerializeField] private Vector2 movementVector;
    [SerializeField] private Vector2 cameraVector;

    [Header("Input Fields")]
    [SerializeField] private float _vertical;
    [SerializeField]private float _horizontal;

    [SerializeField] private float _mouseX;
    [SerializeField] private float _mouseY;

    [SerializeField] private float _moveAmount;
    #endregion

    #region Properties

    public static InputManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindAnyObjectByType<InputManager>();

                if (_instance == null)
                {
                    Debug.LogError("InputManager has not been assigned");
                    Application.Quit();
                }
            }
            return _instance;

        }
    }
    
    public float Vertical
    {
        get { return _vertical; }
        set { _vertical = value; }
    }

    public float Horizontal
    {
        get { return _horizontal; }
        set { _horizontal = value; }
    }

    public float MouseX
    {
        get { return _mouseX; }
        set { _mouseX = value; }
    }
    public float MouseY
    {
        get { return _mouseY; }
        set { _mouseY = value; }
    }
    public float MoveAmount
    {
        get { return _moveAmount; }
        set { _moveAmount = value; }
    }
    #endregion

    #region Start Up
    public void OnAwake()
    {
        playerManager = PlayerManager.Instance;
        playerUIManager = PlayerUIManager.Instance;
    }
    public void OnStart()
    {

    }
    #endregion

    #region Update Functions

    public void OnUpdate()
    {
        TickUpdate();
    }

    private void TickUpdate()
    {
        Horizontal = movementVector.x;
        Vertical = movementVector.y;

        MouseX = cameraVector.x;
        MouseY = cameraVector.y;

        MoveAmount = Mathf.Clamp01(Mathf.Abs(Horizontal) +  Mathf.Abs(Vertical));

    }
    #endregion


    #region Inputs
    private void OnEnable()
    {
        if (playerControls == null)
        {
            playerControls = new PlayerControls();

            playerControls.PlayerMovement.Movement.performed += playerControls => movementVector = playerControls.ReadValue<Vector2>();
            playerControls.PlayerMovement.Camera.performed += playerControls => cameraVector = playerControls.ReadValue<Vector2>();

            playerControls.PlayerMovement.JumpActions.started += playerControls => playerManager.HandlePressJumpKey();
            playerControls.PlayerMovement.JumpActions.canceled += playerControls => playerManager.HandleReleaseJumpKey();

            playerControls.PlayerActions.Interact.performed += playerControls => playerManager.HandleInteract();

            playerControls.PlayerUI.CloseUI.performed += playerControls => playerUIManager.HandleCloseUI();



        }
        playerControls.Enable();
    }

    private void OnDisable()
    {
        playerControls.Disable();
    }
    #endregion
}
