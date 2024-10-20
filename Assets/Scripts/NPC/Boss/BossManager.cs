using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossManager : MonoBehaviour, Interactable
{
    #region Class References
    private static BossManager _instance;

    PlayerUIManager playerUIManager;
    #endregion

    #region Private Fields

    #endregion

    #region Properties

    public static BossManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindAnyObjectByType<BossManager>();

                if (_instance == null)
                {
                    Debug.LogError("BossManager has not been assigned");
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
        playerUIManager = PlayerUIManager.Instance;
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

    public void OnInteract()
    {
        playerUIManager.HandleOpenTargetUI(UIState.Orders);
    }
}
