using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseUIScreen : MonoBehaviour
{
    [SerializeField] private GameObject screenGO;

    public void HandleEnableScreenGO()
    {
        screenGO.gameObject.SetActive(true);
    }

    public void HandleDisableScreenGO()
    {
        screenGO.gameObject.SetActive(false);
    }
}
