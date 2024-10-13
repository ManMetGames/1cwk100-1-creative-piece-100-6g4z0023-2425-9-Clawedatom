using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    #region Class References
    private static PlayerManager _instance;

    InputManager inputManager;

    PlayerLocomotion playerLocomotion;
    PlayerFlight playerFlight;
    #endregion

    #region Private Fields
    [Header("Player Flags")]
    [SerializeField] private bool _moveFlag;
    [SerializeField] private bool _canActionFlag;

    [SerializeField] private bool _sprintFlag;
    
    [SerializeField] private bool _groundedFlag;


    [SerializeField] private bool _flightFlag;

    [SerializeField] private bool _jumpFlag;

    [SerializeField] private bool _glideFlag;


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

    public bool GlideFlag
    {
        get { return _glideFlag; }
        set { _glideFlag = value; }
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

        playerFlight = GetComponent<PlayerFlight>();    
        playerLocomotion = GetComponent<PlayerLocomotion>();
    }
    private void AwakenSiblings()
    {
        playerLocomotion.OnAwake();
        playerFlight.OnAwake();
    }
    public void OnStart()
    {
        StartSiblings();


        SetBools();
    }
    private void SetBools()
    {
        canJump = true;
        
    }

    private void StartSiblings()
    {
        playerLocomotion.OnStart();
        playerFlight.OnStart();
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
        GroundedFlag = playerLocomotion.OnUpdate(inputManager.Vertical, inputManager.Horizontal, GroundedFlag, SprintFlag);

        playerFlight.OnUpdate(GlideFlag, FlightFlag);
        
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
            GlideFlag = false;
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


    public void HandleGlide(bool state)
    {
        if (GroundedFlag || FlightFlag) return;
        GlideFlag = state;
        
        if (!GlideFlag)
        {
            
            playerFlight.HandleDisableGlide();
        }
    }


    private IEnumerator JumpCooldown()
    {
        yield return new WaitForSeconds(jumpDelay);
        canJump = true;
    }
    #endregion
}
