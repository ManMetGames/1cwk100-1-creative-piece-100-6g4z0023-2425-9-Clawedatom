using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrderManager : MonoBehaviour
{
    #region Class References
    private static OrderManager _instance;
    #endregion

    #region Private Fields
    [Header("Order Fields")]
    List<Order> allOrders = new List<Order>();

    [SerializeField] private int maxOrders = 5;
    #endregion

    #region Properties

    public static OrderManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindAnyObjectByType<OrderManager>();

                if (_instance == null)
                {
                    Debug.LogError("OrderManager has not been assigned");
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

    #region Order Functions
    private void GenerateOrders()
    {
        for (int i = 0; i < maxOrders; i++)
        {
            Order newOrder = CreateNewOrder();

            allOrders.Add(newOrder);
        }
    }

    private Order CreateNewOrder()
    {
        Order newOrder = new Order();
        return newOrder;
    }

    public List<Order> GetOrders()
    {
        return allOrders;
    }
    #endregion

}
