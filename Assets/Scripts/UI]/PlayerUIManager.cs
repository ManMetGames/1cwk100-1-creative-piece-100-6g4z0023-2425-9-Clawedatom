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

       

        hudUIManager.OnAwake();
        deliveryUIManager.OnAwake();
    }
    public void OnStart()
    {
        hudUIManager.OnStart();
        deliveryUIManager.OnStart();

        HandleOpenTargetUI(UIState.InGame);
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
            case (UIState.InGame):
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

            case (UIState.Recipient):
            {
                //open recipient
                HandleCloseRecipientUI();
                break;
            }

        }

        //stop movement
        if (targetUI != UIState.InGame)
        {
            playerManager.DisablePlayerMovement();
        }
        currentActiveUI = targetUI;

    }
    public void HandleCloseUI()
    {
        if (currentActiveUI == UIState.InGame) return;
            switch (currentActiveUI)
        {
            case (UIState.InGame):
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

            case (UIState.Recipient):
            {
                //close recipient
                HandleCloseRecipientUI();
                break;
            }

        }
        playerManager.EnablePlayerMovement();
        currentActiveUI = UIState.InGame;
    }

    
    #endregion

    #region HUD Functions


    public void HandleOpenHUDUI()
    {
        hudUIManager.HandleOpenUI();

        //close everything else
        
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
        deliveryUIManager.CloseChildUI();
    }
    public void HandleCloseDeliveryUI()
    {
        deliveryUIManager.HandleCloseUI();
    }
    #endregion

    #region Recipient UI
    public void HandleOpenRecipientUI()
    {

        //open DeliveyUI
        HandleOpenDeliveryUI();
        //open ui
        deliveryUIManager.HandleOpenRecipientUI();


        //disable hud UI
        HandleCloseHUDUI();
    }
    public void HandleCloseRecipientUI()
    {
        //close delivery(last)
        HandleCloseDeliveryUI();

        //open hud ui
        HandleOpenHUDUI();
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
