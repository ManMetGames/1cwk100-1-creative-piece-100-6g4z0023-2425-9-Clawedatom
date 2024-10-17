using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUIManager : MonoBehaviour
{
    #region Class References
    private static PlayerUIManager _instance;

    HUDUIManager hudUIManager;
    DeliveryUIManager deliveryUIManager;
    #endregion

    #region Private Fields

    #endregion

    #region Properties

    public static PlayerUIManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindAnyObjectByType<PlayerUIManager>();

                if (_instance == null)
                {
                    Debug.LogError("PlayerUIManager has not been assigned");
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
        hudUIManager = HUDUIManager.Instance;
        deliveryUIManager = DeliveryUIManager.Instance;


        hudUIManager.OnAwake();
        deliveryUIManager.OnAwake();
    }
    public void OnStart()
    {
        hudUIManager.OnStart();
        deliveryUIManager.OnStart();
    }
    #endregion

    #region Update Functions

    public void OnUpdate()
    {
        hudUIManager.OnUpdate();
    }
    #endregion


    #region HUD Functions
    public void HandleSetFlightSlider(float maxVal)
    {
        hudUIManager.SetFlightSlider(maxVal);
    }
    public void HandleUpdateFlightTimer(float val)
    {
        hudUIManager.UpdateFlightSlider(val);
    }


    #endregion

    #region Order UI
    public void HandleOpenOrderUI(List<Order> orders)
    {
        //open ui
        deliveryUIManager.HandleOpenOrderUI(orders);
    }
    #endregion
}
