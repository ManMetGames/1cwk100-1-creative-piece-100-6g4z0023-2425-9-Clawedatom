using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Order
{
    OrderInfo _oInfo;

    public OrderInfo OInfo
    {
        get { return _oInfo; }
        set { _oInfo = value; }
    }


    public void UpdateOrder()
    {
        //timer
        //events?
    }
}


public class OrderInfo
{
    [SerializeField] int _orderID = -1;

    [SerializeField] NPCSO _recipient;

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

    public string OrderMiniDesc
    {
        get { return _orderMiniDesc; }
    }
}