using System.Collections.Generic;
using UnityEngine;

public class OrdersUIManager : BaseUI
{
    #region Class References
    OrderManager orderManager;
    PlayerManager playerManager;


    OrderDetailsPanel orderDetailsPanel;
    #endregion

    #region Private Fields
    List<Order> updatedOrders = new List<Order>();


    [Header("order preview")]

    [SerializeField] private Transform previewParent;
    [SerializeField] private GameObject orderPreviewPrefab;

    [SerializeField] private int maxOrderPreviews = 10;

    
    List<GameObject> previewSlots = new List<GameObject>();

    [SerializeField] private OrderPreview selectedOrderPreview;

    #endregion

    #region Properties

    
    #endregion

    #region Start Up
    public void OnAwake()
    {
        orderManager = OrderManager.Instance;

        playerManager = PlayerManager.Instance;

        orderDetailsPanel = GetComponentInChildren<OrderDetailsPanel>();
    }
    public void OnStart()
    {
        ClearOrderScreen();
    }
    #endregion

    #region Update Functions

    public void OnUpdate()
    {

    }


    #endregion

    #region Order Functions
    public void AcceptOrder()
    {
        //identify selected order
        orderManager.ProcessAcceptedOrder(selectedOrderPreview.OrderAssigned);
        //add to player order

        //remove from list of orders

        //order manager active order
    }
    #endregion

    #region UI Functions

    public override void HandleOpenUI()
    {
        base.HandleOpenUI();

        //get orders here

        SetUpOrderScreen();
    }
    

    private void SetUpOrderScreen()
    {
        updatedOrders = orderManager.GetOrders();

        int iterations = updatedOrders.Count - 1;
        if (updatedOrders.Count >= maxOrderPreviews)
        {
            iterations = maxOrderPreviews - 1;
        }

        GenerateOrderPreviews(iterations);
    }

    private void ClearOrderScreen()
    {
        foreach(GameObject go in previewSlots)
        {
            Destroy(go);
        }
        //clear detials
        selectedOrderPreview = null;

        orderDetailsPanel.DisablePanel();
    }
    public override void HandleCloseUI()
    {
        orderManager.UpdateOrderList(updatedOrders);

        ClearOrderScreen();

        base.HandleCloseUI();
    }
    #endregion

    #region Order preview
    private void GenerateOrderPreviews(int iterations)
    {
        for (int i = 0; i <= iterations; i++)
        {
            Order order = updatedOrders[i];

            CreateOrderPreview(order);
        }
    }

    private void CreateOrderPreview(Order order)
    {
        GameObject orderPreviewGO = Instantiate(orderPreviewPrefab, previewParent);
        orderPreviewGO.GetComponent<OrderPreview>().SetUpOrderPreview(order);


        previewSlots.Add(orderPreviewGO);

    }

    public void HandleOpenOrderPreview(OrderPreview preview)
    {
        //set up order info
        EnableOrderDetailsPanel(preview);
    }
    #endregion

    #region Order Details
    public void EnableOrderDetailsPanel(OrderPreview previewSelected)
    {
        orderDetailsPanel.EnablePanel(previewSelected);

        selectedOrderPreview = previewSelected;
    }

    public void DisableOrderDetailsPanel()
    {
        orderDetailsPanel.DisablePanel();

        selectedOrderPreview = null;
    }
    #endregion
}
