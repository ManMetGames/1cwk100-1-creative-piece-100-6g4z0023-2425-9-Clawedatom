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

    GameData gameData;
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


       
    }

    private void AssignClasses()
    {
        gameData = GameData.Instance;

        inputManager = InputManager.Instance;
        cameraManager = CameraManager.Instance;
        playerManager = PlayerManager.Instance;

        playerUIManager = PlayerUIManager.Instance;

        orderManager = OrderManager.Instance;

        bossManager = BossManager.Instance;
    }

    private void AwakenClasses()
    {
        gameData.OnAwake();

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

        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = false;
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

        inputManager.OnUpdate();
        if (playerManager.MoveFlag)
        {
            cameraManager.OnUpdate(inputManager.MouseX, inputManager.MouseY);
        }
        else
        {
            inputManager.MoveAmount = 0;
        }

        playerUIManager.OnUpdate();

        orderManager.OnUpdate();

        bossManager.OnUpdate();
    }
    #endregion


    #region Game Functions
    
    #endregion
}
