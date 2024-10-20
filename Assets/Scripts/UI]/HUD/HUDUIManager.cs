using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDUIManager : BaseUI
{
    #region Class References
    private static HUDUIManager _instance;
    #endregion

    #region Private Fields
    [Header("Slider")]
    [SerializeField] private Slider flightSlider;

    #endregion

    #region Properties

    public static HUDUIManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindAnyObjectByType<HUDUIManager>();

                if (_instance == null)
                {
                    Debug.LogError("HUDUIManager has not been assigned");
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

    #region HUD UI
    public override void HandleOpenUI()
    {
        base.HandleOpenUI();
    }
    public override void HandleCloseUI()
    {
        base.HandleCloseUI();
    }
    #endregion

    #region Slider
    public void SetFlightSlider(float maxVal)
    {
        flightSlider.minValue = 0f;
        flightSlider.maxValue = maxVal;
        flightSlider.value = maxVal;
    }

    public void UpdateFlightSlider(float val)
    {
        flightSlider.value = val;
    }

    #endregion
}
