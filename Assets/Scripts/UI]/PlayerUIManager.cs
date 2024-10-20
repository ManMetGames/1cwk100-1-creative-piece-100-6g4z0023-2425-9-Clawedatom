using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class PlayerUIManager : MonoBehaviour
{
    #region Class References
    private static PlayerUIManager _instance;

    PlayerManager playerManager;

    HUDUIManager hudUIManager;
    DeliveryUIManager deliveryUIManager;

    OrderManager orderManager;
    #endregion

    #region Private Fields
    [Header("UI Fields")]
    [SerializeField]UIState currentActiveUI;
    #endregion

    #region Properties

    public static PlayerUIManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindAnyObjectByType<PlayerUIManager>();

                if (_instance == null)
                {
                    Debug.LogError("PlayerUIManager has not been assigned");
                    Application.Quit();
                }
            }
            return _instance;

        }
    }
    #endregion

    #region Start Up
    public void OnAwake()
    {
        playerManager = PlayerManager.Instance;

        hudUIManager = HUDUIManager.Instance;
        deliveryUIManager = DeliveryUIManager.Instance;

        orderManager = OrderManager.Instance;

        hudUIManager.OnAwake();
        deliveryUIManager.OnAwake();
    }
    public void OnStart()
    {
        hudUIManager.OnStart();
        deliveryUIManager.OnStart();
    }
    #endregion

    #region Update Functions

    public void OnUpdate()
    {
        hudUIManager.OnUpdate();
    }
    #endregion


    #region Manager Functions

    public void HandleOpenTargetUI(UIState targetUI)
    {
        switch (targetUI)
        {
            case (UIState.HUD):
            {
                //openHUDUI
                HandleOpenHUDUI();
                break;
            }
            
            case (UIState.Orders):
            {
                //openOrders
                HandleOpenOrderUI();
                break;
            }

        }

        //stop movement
        playerManager.DisablePlayerMovement();
        currentActiveUI = targetUI;

    }
    public void HandleCloseUI()
    {
        switch (currentActiveUI)
        {
            case (UIState.HUD):
            {
                //closeHUDUI
                HandleCloseHUDUI();
                break;
            }

            case (UIState.Orders):
            {
                //close orders
                HandleCloseOrdersUI();
                break;
            }

        }
        playerManager.EnablePlayerMovement();
        currentActiveUI = UIState.closed;
    }
    #endregion

    #region HUD Functions

   
    public void HandleOpenHUDUI()
    {
        hudUIManager.HandleOpenUI();
    }

    public void HandleCloseHUDUI()
    {
        hudUIManager.HandleCloseUI();
    }
    public void HandleSetFlightSlider(float maxVal)
    {
        hudUIManager.SetFlightSlider(maxVal);
    }
    public void HandleUpdateFlightTimer(float val)
    {
        hudUIManager.UpdateFlightSlider(val);
    }


    #endregion

    #region delivery UI
    public void HandleOpenDeliveryUI()
    {
        deliveryUIManager.HandleOpenUI();
    }
    public void HandleCloseDeliveryUI()
    {
        deliveryUIManager.HandleCloseUI();
    }
    #endregion

    #region Order UI
    public void HandleOpenOrderUI()
    {

        //open DeliveyUI
        HandleOpenDeliveryUI();
        //open ui
        deliveryUIManager.HandleOpenOrderUI();


        //disable hud UI
        HandleCloseHUDUI();
    }
    public void HandleCloseOrdersUI()
    {
        //close delivery(last)
        HandleCloseDeliveryUI();

        //open hud ui
        HandleOpenHUDUI();
    }

    
    #endregion
}
