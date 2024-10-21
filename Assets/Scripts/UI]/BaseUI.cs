using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseUI : MonoBehaviour, BaseUIInterface
{
    [SerializeField] private GameObject screenGO;

    [SerializeField] private UIState _typeOfUI;

    public UIState TypeOfUI
    {
        get { return _typeOfUI; }
        set { _typeOfUI = value; }
    }

    public virtual void HandleCloseUI()
    {
        HandleDisableScreenGO();
    }

    public virtual void HandleOpenUI()
    {
        HandleEnableScreenGO();
    }

    public void HandleEnableScreenGO()
    {
        screenGO.gameObject.SetActive(true);
    }

    public void HandleDisableScreenGO()
    {
        screenGO.gameObject.SetActive(false);
    }
}
public enum UIState
{
    InGame,
    Recipient,
    Orders,

}