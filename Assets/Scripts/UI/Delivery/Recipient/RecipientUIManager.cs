using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecipientUIManager : BaseUI
{
    #region Class References
    OrderManager orderManager;

    OrderSummaryPanel orderSummaryPanel;
    DeliveryPanel deliveryPanel;

    #endregion

    #region Private Fields

    #endregion

    #region Properties

    
    #endregion

    #region Start Up
    public void OnAwake()
    {
        orderManager = OrderManager.Instance;
        deliveryPanel = GetComponentInChildren<DeliveryPanel>();

        orderSummaryPanel = GetComponentInChildren<OrderSummaryPanel>();

        orderSummaryPanel.OnAwake();
    }
    public void OnStart()
    {
        orderSummaryPanel.OnStart();
        
    }
    #endregion

    #region Update Functions

    public void OnUpdate()
    {

    }
    #endregion

    #region Recipient Functions
    public override void HandleCloseUI()
    {
        orderSummaryPanel.DisablePanel();

        base.HandleCloseUI();
    }

    public override void HandleOpenUI()
    {
        base.HandleOpenUI();

        deliveryPanel.EnablePanel();
        orderSummaryPanel.DisablePanel();
    }

    public void ProcessDelivery()
    {
        //get active order
        Order order = orderManager.CompleteOrder();
        //retrieve order summary


        //display order summary
        deliveryPanel.DisablePanel();
        orderSummaryPanel.EnablePanel(order);

        
        print("Order Complete");
    }
    #endregion
}
