using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    #region Class References
    private static PlayerManager _instance;

    InputManager inputManager;
    PlayerUIManager playerUIManager;

    PlayerLocomotion playerLocomotion;
    PlayerFlight playerFlight;

    PlayerAnimationManager playerAnimationManager;

    PlayerInteract playerInteract;
    #endregion

    #region Private Fields
    [Header("Player Flags")]
    [SerializeField] private bool _moveFlag;
    [SerializeField] private bool _canActionFlag;

    [SerializeField] private bool _sprintFlag;
    
    [SerializeField] private bool _groundedFlag;


    [SerializeField] private bool _flightFlag;

    [SerializeField] private bool _jumpFlag;



    [Header("Player Cans")]
    [SerializeField] private bool canJump;


    [Header("Temp Fields")]
    [SerializeField] private float jumpDelay;
    #endregion

    #region Properties

    public static PlayerManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindAnyObjectByType<PlayerManager>();

                if (_instance == null)
                {
                    Debug.LogError("PlayerManager has not been assigned");
                    Application.Quit();
                }
            }
            return _instance;

        }
    }

    public bool MoveFlag
    {
        get { return _moveFlag; }
        set { _moveFlag = value; }
    }

    public bool CanActionFlag
    {
        get { return _canActionFlag; }
        set { _canActionFlag = value; }
    }

    public bool SprintFlag
    {
        get { return _sprintFlag; }
        set { _sprintFlag = value; }
    }
    public bool JumpFlag
    {
        get { return _jumpFlag; }
        set { _jumpFlag = value; }
    }
    public bool FlightFlag
    {
        get { return _flightFlag; }
        set { _flightFlag = value; }
    }

    public bool GroundedFlag
    {
        get { return _groundedFlag; }
        set { _groundedFlag = value; }
    }

        
    #endregion

    #region Start Up
    public void OnAwake()
    {
        AssignSiblings();
        AwakenSiblings();


    }

    private void AssignSiblings()
    {
        inputManager = InputManager.Instance;
        playerUIManager = PlayerUIManager.Instance;

        playerFlight = GetComponent<PlayerFlight>();    
        playerLocomotion = GetComponent<PlayerLocomotion>();

        playerAnimationManager = GetComponentInChildren<PlayerAnimationManager>();

        playerInteract = GetComponent<PlayerInteract>();
    }
    private void AwakenSiblings()
    {
        playerLocomotion.OnAwake();
        playerFlight.OnAwake();

        playerAnimationManager.OnAwake();

        playerInteract.OnAwake();
    }
    public void OnStart()
    {
        StartSiblings();


        SetBools();
    }
    private void SetBools()
    {
        canJump = true;
        EnablePlayerMovement();
    }

    private void StartSiblings()
    {
        playerLocomotion.OnStart();
        playerFlight.OnStart();

        playerAnimationManager.OnStart();

        playerInteract.OnStart(); 
    }
    #endregion

    #region Update Functions

    public void OnUpdate()
    {
        UpdateSiblings();


        CheckBools();
        ResetBools();
    }

    private void CheckBools()
    {
        if (JumpFlag)
        {
            HandleJump();
        }
    }

    private void ResetBools()
    {
        JumpFlag = false;
    }

    private void UpdateSiblings()
    {
        GroundedFlag = playerLocomotion.OnUpdate(inputManager.Vertical, inputManager.Horizontal, MoveFlag ,GroundedFlag, SprintFlag);

        playerFlight.OnUpdate(FlightFlag);

        playerInteract.OnUpdate();

        playerAnimationManager.OnUpdate(inputManager.MoveAmount, 0f, GroundedFlag, SprintFlag, FlightFlag);
    }


    private void HandleJump()
    {
        if (canJump && GroundedFlag)
        {
            playerLocomotion.Jump();
            canJump = false;
            StartCoroutine(JumpCooldown());
        }
    }
    #endregion

    #region Input Actions

    public void HandleInteract()
    {
        playerInteract.Interact();
    }

    public void HandlePressJumpKey()
    {
        if (GroundedFlag)
        {
            EnableJump();
        }
        else
        {
            //EnableFlight
            FlightFlag = true;
            playerFlight.HandleEnableFlight();
        }
    }

    public void HandleReleaseJumpKey()
    {
        FlightFlag = false;
        playerFlight.HandleDisableFlight();
        
    }
    public void EnableJump()
    {
        JumpFlag = true;
        
        
    }

    public void DisableFlight()
    {
        FlightFlag = false;
    }


    


    private IEnumerator JumpCooldown()
    {
        yield return new WaitForSeconds(jumpDelay);
        canJump = true;
    }
    #endregion

    #region Movement

    public void EnablePlayerMovement()
    {
        MoveFlag = true;
    }
    public void DisablePlayerMovement()
    {
        //cant move
        MoveFlag = false;
    }


    #endregion


    #region NPC Functions
    public void NPC_RecipientInteract()
    {
        playerUIManager.HandleOpenTargetUI(UIState.Recipient);
    }
    public void NPC_BossInteract()
    {
        playerUIManager.HandleOpenTargetUI(UIState.Orders);
    }
    public void NPC_WorldInteract()
    {

    }
    #endregion
}
