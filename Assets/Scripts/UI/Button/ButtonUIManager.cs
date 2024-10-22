using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonUIManager : MonoBehaviour
{
    #region Class References
    private static ButtonUIManager _instance;


    PlayerUIManager playerUIManager;

    EventSystem eventSystem;
    GraphicRaycaster graphicRaycaster;
    PointerEventData eventData;
    #endregion

    #region Private Fields
    [Header("Button Fields")]
    [SerializeField] private UIButton _currentButtonHovered;

    
    #endregion

    #region Properties

    public static ButtonUIManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindAnyObjectByType<ButtonUIManager>();

                if (_instance == null)
                {
                    Debug.LogError("ButtonUIManager has not been assigned");
                    Application.Quit();
                }
            }
            return _instance;

        }
    }

    public UIButton CurrentButtonHovered
    {
        get { return _currentButtonHovered; }
        set { _currentButtonHovered = value; }
    }
    #endregion

    #region Start Up
    public void OnAwake()
    {
        graphicRaycaster = GetComponent<GraphicRaycaster>();
        eventSystem = EventSystem.current;
        playerUIManager = PlayerUIManager.Instance;
    }
    public void OnStart()
    {

    }
    #endregion

    #region Update Functions

    public void OnUpdate()
    {
        CurrentButtonHovered = HandleButtonRaycast();
        print(CurrentButtonHovered);
    }

    private UIButton HandleButtonRaycast()
    {
        eventData = new PointerEventData(eventSystem);
        eventData.position = Input.mousePosition;
        List<RaycastResult> results = new List<RaycastResult>();
        graphicRaycaster.Raycast(eventData, results);

        if (results.Count > 0)
        {
            foreach (RaycastResult result in results)
            {
                
                if (result.gameObject.tag== "UIButton")
                {
                    return result.gameObject.GetComponent<UIButton>();
                }
            }
        }
        return null;
    }
    #endregion

    #region Button Functions
    public void HandleButtonClick()
    {
        CurrentButtonHovered.OnButtonClick();
    }
    #endregion

    #region Buttons
    public void Button_OrderUI_OrderPreview(GameObject button)
    {
        
        playerUIManager.Order_HandleOrderPreviewClick(button.GetComponent<OrderPreview>());
    }

    public void Button_OrderUI_CloseOrderDetails()
    {
        playerUIManager.Order_HandleCloseOrderDetails();
    }

    public void Button_OrderUI_AcceptOrder()
    {
        playerUIManager.Order_HandleAcceptOrder();
    }
    #endregion
}
