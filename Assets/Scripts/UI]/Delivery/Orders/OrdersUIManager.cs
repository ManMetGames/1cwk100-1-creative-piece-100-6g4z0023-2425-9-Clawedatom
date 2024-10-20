using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrdersUIManager : BaseUI
{
    #region Class References
    OrderManager orderManager;
    #endregion

    #region Private Fields

    #endregion

    #region Properties

    
    #endregion

    #region Start Up
    public void OnAwake()
    {
        orderManager = OrderManager.Instance;
    }
    public void OnStart()
    {


        HandleDisableScreenGO();
    }
    #endregion

    #region Update Functions

    public void OnUpdate()
    {

    }


    #endregion

    #region UI Functions

    public override void HandleOpenUI()
    {
        base.HandleOpenUI();

        //get orders here
    }
    public void HandleEnableOrderUI(List<Order> orders)
    {
        HandleOpenUI();
        //show orders
    }
    #endregion
}
