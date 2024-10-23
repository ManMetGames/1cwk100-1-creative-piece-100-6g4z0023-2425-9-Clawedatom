using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrderManager : MonoBehaviour
{
    #region Class References
    private static OrderManager _instance;

    PlayerManager playerManager;
    GameData gameData;
    #endregion

    #region Private Fields
    [Header("Order Fields")]
    [SerializeField]List<Order> allOrders = new List<Order>();

    [SerializeField] private int maxOrders = 5;


    [SerializeField] private Order _activeOrder;
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

    public Order ActiveOrder
    {
        get { return _activeOrder; }
        set { _activeOrder = value; }
    }
    #endregion

    #region Start Up
    public void OnAwake()
    {
        gameData = GameData.Instance;

        playerManager = PlayerManager.Instance;
    }
    public void OnStart()
    {

        GenerateOrders();
        
    }
    #endregion

    #region Update Functions

    public void OnUpdate()
    {
        if (ActiveOrder.OInfo.OrderID != -1)
        {
            ActiveOrder.UpdateOrder();
        }
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
        int random = Random.Range(0, gameData.GameRecipientNPCs.Count - 1);
        newInfo.Recipient = gameData.GameRecipientNPCs[random].NPC;
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

    private void SetActiveOrder(Order order)
    {
        ActiveOrder = order;
    }

    public void ProcessAcceptedOrder(Order order)
    {
        //give player order magic pouch
        SetActiveOrder(order);
        //give recpient order id
        foreach (RecipientManager recipientManager in gameData.GameRecipientNPCs)
        {
            //check if its the correct npc
            if (recipientManager.NPC == order.OInfo.Recipient)
            {
                recipientManager.HandleSetRecipientOrderID(order.OInfo.OrderID);
                break;
            }
        }


    
    }

    public Order CompleteOrder()
    {
        ActiveOrder.GenerateSummary();

        Order order = ActiveOrder;

        ActiveOrder = null;

        return order;
    }
    #endregion

}
