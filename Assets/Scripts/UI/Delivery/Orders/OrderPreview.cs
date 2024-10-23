using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class OrderPreview : MonoBehaviour
{
	#region Private Fields
	[SerializeField] private Order _orderAssigned;

	[SerializeField] private TMP_Text destinationText;
	[SerializeField] private List<GameObject> moneyIconGO;
	[SerializeField] private TMP_Text timeText;
	[SerializeField] private Image icon;



	public Order OrderAssigned
	{
		get { return _orderAssigned; }
		set { _orderAssigned = value; }
	}
	#endregion

		#region Preview Functions
	public void SetUpOrderPreview(Order order)
	{
		OrderAssigned = order;

		SetUpSlot();
	}

	private void SetUpSlot()
	{
		destinationText.text = "" + OrderAssigned.OInfo.Recipient.NPCName + " At " + OrderAssigned.OInfo.Recipient.AssignedLocation.LocationName;

		ChooseMoneyIcon();

		icon.sprite = OrderAssigned.OInfo.Recipient.NPCIcon;

		//button

		UIButton button = GetComponent<UIButton>();
		button.onButtonClick.AddListener(() => ButtonUIManager.Instance.Button_OrderUI_OrderPreview(this.gameObject));
		
	}

	private void ChooseMoneyIcon()
	{
		foreach (GameObject go in moneyIconGO)
		{
			go.SetActive(false);
		}

		int index = OrderAssigned.OInfo.Difficulty - 1;
		moneyIconGO[index].SetActive(true);
	}

    public void DestroySelf()
    {
		Destroy(this.gameObject);
    }
    #endregion
}
