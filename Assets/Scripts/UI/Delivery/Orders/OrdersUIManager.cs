using System.Collections.Generic;
using UnityEngine;

public class OrdersUIManager : BaseUI
{
    #region Class References
    OrderManager orderManager;
    #endregion

    #region Private Fields
    List<Order> updatedOrders = new List<Order>();


    [SerializeField] private Transform previewParent;
    [SerializeField] private GameObject orderPreviewPrefab;

    [SerializeField] private int maxOrderPreviews = 10;
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

        print("Created order Preview");
    
    }
    public override void HandleCloseUI()
    {
        orderManager.UpdateOrderList(updatedOrders);

        base.HandleCloseUI();
    }
    #endregion
}
