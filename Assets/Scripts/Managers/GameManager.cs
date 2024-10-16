using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region Class References
    private static GameManager _instance;

    InputManager inputManager;
    PlayerManager playerManager;
    CameraManager cameraManager;

    PlayerUIManager playerUIManager;
    OrderManager orderManager;


    BossManager bossManager;

    #endregion

    #region Private Fields

    #endregion

    #region Properties

    public static GameManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindAnyObjectByType<GameManager>();

                if (_instance == null)
                {
                    Debug.LogError("GameManager has not been assigned");
                    Application.Quit();
                }
            }
            return _instance;

        }
    }
    #endregion

    #region Start Up
    private void Awake()
    {
        OnAwake();
    }
    private void Start()
    {
        OnStart();
    }
    public void OnAwake()
    {
        AssignClasses();
        AwakenClasses();


        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void AssignClasses()
    {
        inputManager = InputManager.Instance;
        cameraManager = CameraManager.Instance;
        playerManager = PlayerManager.Instance;

        playerUIManager = PlayerUIManager.Instance;

        orderManager = OrderManager.Instance;

        bossManager = BossManager.Instance;
    }

    private void AwakenClasses()
    {
        inputManager.OnAwake();
        cameraManager.OnAwake();
        playerManager.OnAwake();

        playerUIManager.OnAwake();

        orderManager.OnAwake();

        bossManager.OnAwake();
    }
    public void OnStart()
    {
        StartClasses();
    }

    private void StartClasses()
    {
        inputManager.OnStart();
        cameraManager.OnStart();
        playerManager.OnStart();

        playerUIManager.OnStart();

        orderManager.OnStart();

        bossManager.OnStart();
    }
    #endregion

    #region Update Functions

    private void Update()
    {
        OnUpdate();
    }
    public void OnUpdate()
    {
        UpdateClasses();
    }

    private void UpdateClasses()
    {
        playerManager.OnUpdate();
        cameraManager.OnUpdate(inputManager.MouseX, inputManager.MouseY);
        inputManager.OnUpdate();

        playerUIManager.OnUpdate();

        orderManager.OnUpdate();

        bossManager.OnUpdate();
    }
    #endregion


    #region Game Functions
    public void HandleOpenBossUI()
    {
        //get orders

        //open ui with orders
        playerUIManager.HandleOpenOrderUI(orderManager.GetOrders());
        //playerMnaager.freeze player and stuff
        playerManager.StopPlayerMovement();

    }
    #endregion
}
