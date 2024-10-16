using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeliveryUIManager : BaseUIScreen
{
    #region Class References
    private static DeliveryUIManager _instance;
    #endregion

    #region Private Fields

    #endregion

    #region Properties

    public static DeliveryUIManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindAnyObjectByType<DeliveryUIManager>();

                if (_instance == null)
                {
                    Debug.LogError("DeliveryUIManager has not been assigned");
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
}
