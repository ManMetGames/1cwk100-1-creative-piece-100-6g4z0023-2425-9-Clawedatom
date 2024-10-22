using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDelivery : MonoBehaviour
{
    #region Class References

    #endregion

    #region Private Fields
    [Header("Delivery Fields")]
    [SerializeField] private Order _activeOrder;
    #endregion

    #region Properties
    public Order ActiveOrder
    {
        get { return _activeOrder; }
        set { _activeOrder = value; }
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

    #region Delivery
    public void SetActiveOrder(Order order)
    {
        ActiveOrder = order; 
    }
    #endregion
}
