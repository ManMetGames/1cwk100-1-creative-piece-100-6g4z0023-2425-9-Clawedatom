using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrderManager : MonoBehaviour
{
    #region Class References
    private static OrderManager _instance;

    GameData gameData;
    #endregion

    #region Private Fields
    [Header("Order Fields")]
    [SerializeField]List<Order> allOrders = new List<Order>();

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
        gameData = GameData.Instance;
    }
    public void OnStart()
    {

        GenerateOrders();
        
    }
    #endregion

    #region Update Functions

    public void OnUpdate()
    {

    }
    #endregion

    #region Order Functions
    public void UpdateOrderList(List<Order> updatedOrders)
    {
        allOrders = updatedOrders;
    }

    private void GenerateOrders()
    {
        for (int i = 0; i < maxOrders; i++)
        {
            Order newOrder = CreateNewOrder();
            newOrder.GenerateStory();
            allOrders.Add(newOrder);
        }
    }

    private Order CreateNewOrder()
    {
        OrderInfo newInfo = new OrderInfo();

        //id
        newInfo.OrderID = Random.Range(10000, 99999);
        //recipient
        int random = Random.Range(0, gameData.GameRecipientNPCS.Count - 1);
        newInfo.Recipient = gameData.GameRecipientNPCS[random];
        //item
        random = Random.Range(0, gameData.GameOrderItems.Count - 1);
        newInfo.ItemOrdered = gameData.GameOrderItems[random];
        
        //difficulty
        random = Random.Range(1, 4);
        newInfo.Difficulty = random;
        //timeLimit
        newInfo.TimeLimit = 60f;
        //reward
        newInfo.Value = 10;

        Order newOrder = new Order(newInfo);

        return newOrder;
    }

    public List<Order> GetOrders()
    {
        return allOrders;
    }
    #endregion

}
