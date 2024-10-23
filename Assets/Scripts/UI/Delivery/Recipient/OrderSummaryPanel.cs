using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class OrderSummaryPanel : MonoBehaviour
{
    #region Class References

    #endregion

    #region Private Fields
    [SerializeField] private GameObject orderSummaryPanelGO;

    [Header("Order Summary Objects")]
    [SerializeField] private TMP_Text orderSummaryText;
    [SerializeField] private TMP_Text goldRecievedText;
    [SerializeField] private Image rankImage;
    #endregion

    #region Properties

    #endregion

    #region Start Up
    public void OnAwake()
    {

    }
    public void OnStart()
    {

    }
    #endregion

    #region Functions
    public void EnablePanel(Order order)
    {
        orderSummaryPanelGO.SetActive(true);

        orderSummaryText.text = order.OrderSummary;
    }

    public void DisablePanel()
    {
        orderSummaryText.text = "";
        goldRecievedText.text = "";

        rankImage.sprite = null;


        orderSummaryPanelGO.SetActive(false);       
    }
    #endregion

}
