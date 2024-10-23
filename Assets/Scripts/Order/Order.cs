using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Order
{
    public Order(OrderInfo info)
    {
        OInfo = info;
    }

    [SerializeField] private OrderInfo _oInfo;

    [SerializeField] private float timeElapsed;

    [SerializeField] private string _orderSummary;
    public OrderInfo OInfo
    {
        get { return _oInfo; }
        set { _oInfo = value; }
    }

    public string OrderSummary
    {
        get { return _orderSummary; }
        set { _orderSummary = value; }
    }

    public void GenerateStory()
    {
        OInfo.OrderMiniDesc = "" + OInfo.Recipient.NPCName + " wants " + OInfo.ItemOrdered.ItemName + " delivered in " + OInfo.TimeLimit + "s."; 
    }


    public void UpdateOrder()
    {
        //timer
        timeElapsed += Time.deltaTime;
        //events?
    }

    public void GenerateSummary()
    {
        int rank = CalculateRank();
        int goldEarned = 100;

        OrderSummary = "";

        if (rank == 0)
        {
            OrderSummary = "Great job! You delivered " + OInfo.Recipient.NPCName + "'s package of " + OInfo.ItemOrdered.ItemName + " in only " + timeElapsed + "s. Because you did well we will reward you will maximum payment for this. Keep up the good work";
        }
        else if (rank == 1)
        {
            OrderSummary = "Order Complete! You delivered " + OInfo.Recipient.NPCName + "'s package of " + OInfo.ItemOrdered.ItemName + " in " + timeElapsed + "s. You have had a slight pay cut for being over the requried delivery time.";
            goldEarned = 75;
        }
        else if (rank == 2)
        {
            OrderSummary = "You delivered " + OInfo.Recipient.NPCName + "'s package of " + OInfo.ItemOrdered.ItemName + " in " + timeElapsed + "s. This is way off the requried delivery time therefore we will significantly cut your pay. Do better next time";
            goldEarned = 30;
        }
        else if (rank == 3)
        {
            OrderSummary = "This is a terrible performance... You delivered " + OInfo.Recipient.NPCName + "'s package of " + OInfo.ItemOrdered.ItemName + " in " + timeElapsed + "s. Despite still delivering the package it took you a crazy amount of time, your pay will reflect your poor performance";
            goldEarned = 10;
        }

        GameData.Instance.GetRankIcon(rank);
        
    }

    private int CalculateRank()
    {
        int rank = 0;
        if (timeElapsed < OInfo.TimeLimit)
        {
            //rank 0/A
        }
        if (timeElapsed > OInfo.TimeLimit && timeElapsed < OInfo.TimeLimit + (OInfo.TimeLimit / 2))
        {
            //rank 1/B
            rank = 1;
        }
        if (timeElapsed > OInfo.TimeLimit + (OInfo.TimeLimit / 2) && timeElapsed < OInfo.TimeLimit * 2)
        {
            //rank 2/C
            rank = 2;
        }
        if (timeElapsed > OInfo.TimeLimit * 2)
        {
            //rank 3/F
            rank = 3;
        }

        return rank;
    }
}


[System.Serializable]
public class OrderInfo
{
    [SerializeField] private int _orderID = -1;

    [SerializeField] private NPCSO _recipient;

    [SerializeField] private OrderItemSO _itemOrdered;

    [SerializeField] private int _difficulty;

    [SerializeField] private float _timeLimit;

    [SerializeField] private int _value;

    [TextArea] [SerializeField] private string _orderMiniDesc;


    public int OrderID
    {
        get { return _orderID; }
        set { _orderID = value; }
    }

    public NPCSO Recipient
    {
        get { return _recipient; }
        set { _recipient = value; }
    }

    public OrderItemSO ItemOrdered
    {
        get { return _itemOrdered; }
        set { _itemOrdered = value; }
    }
    public int Difficulty
    {
        get { return _difficulty; }
        set { _difficulty = value; }
    }

    public float TimeLimit
    {
        get { return _timeLimit; }
        set { _timeLimit = value; }
    }

    public int Value
    {
        get { return _value; }
        set { _value = value; }
    }

    public string OrderMiniDesc
    {
        get { return _orderMiniDesc; }
        set { _orderMiniDesc = value; }
    }
}