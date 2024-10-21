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

    public OrderInfo OInfo
    {
        get { return _oInfo; }
        set { _oInfo = value; }
    }

    public void GenerateStory()
    {
        OInfo.OrderMiniDesc = "" + OInfo.Recipient.NPCName + " wants " + "(Make Delivery items)" + "delivered in " + OInfo.TimeLimit + "s."; 
    }


    public void UpdateOrder()
    {
        //timer
        //events?
    }
}


[System.Serializable]
public class OrderInfo
{
    [SerializeField] private int _orderID = -1;

    [SerializeField] private NPCSO _recipient;

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