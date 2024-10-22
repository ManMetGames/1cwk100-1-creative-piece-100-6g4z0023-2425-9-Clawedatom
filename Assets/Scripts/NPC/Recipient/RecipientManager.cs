using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecipientManager : NPCManager
{

    #region Class References

    #endregion

    #region Private Fields
    

    [SerializeField] private int _orderID;
    #endregion

    #region Properties
    public RecipientManager()
    {
        TypeOfNPC = NPCType.recipient;
    }
    
    

    public int OrderID
    {
        get { return _orderID; }
        set { _orderID = value; }
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

    #region Recipient Functions
    public void HandleSetRecipientOrderID(int id)
    {
        OrderID = id;
    }
    #endregion
}
