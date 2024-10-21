using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Order
{
    public void UpdateOrder()
    {
        //timer
        //events?
    }
}


public class OrderInfo
{
    [SerializeField]int _orderID = -1;

    public int OrderID
    {
        get { return _orderID; }
        set { _orderID = value; }
    }
}