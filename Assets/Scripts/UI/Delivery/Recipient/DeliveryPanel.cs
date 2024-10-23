using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeliveryPanel : MonoBehaviour
{
    [SerializeField] private GameObject deliveryPanelGO;

    public void EnablePanel()
    {
        deliveryPanelGO.SetActive(true);
    }

    public void DisablePanel()
    {
        deliveryPanelGO.SetActive(false);
    }
}
