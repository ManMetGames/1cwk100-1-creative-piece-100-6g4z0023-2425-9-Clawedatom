using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "New Item", menuName = "New Scriptable Object/ New Order Item")]
public class OrderItemSO : ScriptableObject
{
    [SerializeField] private string _itemName;

    public string ItemName
    {
        get { return _itemName;  }
        set { _itemName = value; }
    }
}
