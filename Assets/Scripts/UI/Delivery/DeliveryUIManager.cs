using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeliveryUIManager : BaseUI
{
    #region Class References
    private static DeliveryUIManager _instance;

    OrdersUIManager ordersUIManager;
    RecipientUIManager recipientUIManager;
    #endregion

    #region Private Fields

    #endregion

    #region Properties

    public static DeliveryUIManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindAnyObjectByType<DeliveryUIManager>();

                if (_instance == null)
                {
                    Debug.LogError("DeliveryUIManager has not been assigned");
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
        ordersUIManager = GetComponentInChildren<OrdersUIManager>();
        recipientUIManager = GetComponentInChildren<RecipientUIManager>();


        ordersUIManager.OnAwake();
        recipientUIManager.OnAwake();
    }
    public void OnStart()
    {
        ordersUIManager.OnStart();
        recipientUIManager.OnStart();

    }
    #endregion

    #region Update Functions

    public void OnUpdate()
    {
        recipientUIManager.OnUpdate();
        ordersUIManager.OnUpdate();
    }


    #endregion

    #region UI Functions

    public void CloseChildUI()
    {
        recipientUIManager.HandleCloseUI();
        ordersUIManager.HandleCloseUI();
    }
    public void HandleOpenRecipientUI()
    {
        recipientUIManager.HandleOpenUI();
    }
   

    public void HandleOpenOrderUI()
    {
        ordersUIManager.HandleOpenUI();

        

    }
    public override void HandleOpenUI()
    {
        base.HandleOpenUI();
    }
    public override void HandleCloseUI()
    {
        CloseChildUI();

        base.HandleCloseUI(); // last
    }
    #endregion
}