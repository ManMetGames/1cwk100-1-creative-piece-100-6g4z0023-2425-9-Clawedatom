using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class UIButton : MonoBehaviour
{
    [System.Serializable]public class ButtonEvent : UnityEvent { }

    public ButtonEvent onButtonClick;

    
    public void OnButtonClick()
    {
        onButtonClick.Invoke();
    }
}
