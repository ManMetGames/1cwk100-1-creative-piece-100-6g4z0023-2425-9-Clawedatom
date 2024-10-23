using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class OrderDetailsPanel : MonoBehaviour
{

    #region Private Fields
    [SerializeField] private GameObject orderDetailsGO;

    [SerializeField] private OrderPreview previewShowing;

    [SerializeField] private TMP_Text descriptionText;
    [SerializeField] private TMP_Text goldValueText;
    

    [SerializeField] private TMP_Text timeLimitText;
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
    public void EnablePanel(OrderPreview preview)
    {
        previewShowing = preview;

        orderDetailsGO.SetActive(true);

        SetUpPanel();
    }

    private void SetUpPanel()
    {
        descriptionText.text = "" + previewShowing.OrderAssigned.OInfo.OrderMiniDesc;

        goldValueText.text = previewShowing.OrderAssigned.OInfo.Value + "g";

        timeLimitText.text = previewShowing.OrderAssigned.OInfo.TimeLimit + "s";
    }

    public void DisablePanel()
    {
        if (previewShowing == null) return;

        previewShowing = null;

        orderDetailsGO?.SetActive(false);
    }
    #endregion
}
