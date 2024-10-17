using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrdersUIManager : BaseUIScreen
{
    #region Class References
    
    #endregion

    #region Private Fields

    #endregion

    #region Properties

    
    #endregion

    #region Start Up
    public void OnAwake()
    {

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

    #region Toggle Functions
    public void HandleEnableOrderUI(List<Order> orders)
    {
        HandleEnableScreenGO();
        //show orders
    }
    #endregion
}
