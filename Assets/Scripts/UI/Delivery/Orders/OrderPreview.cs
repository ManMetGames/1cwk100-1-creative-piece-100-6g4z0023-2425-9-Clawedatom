using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class OrderPreview : MonoBehaviour
{
	#region Private Fields
	[SerializeField] private Order orderAssigned;

	[SerializeField] private TMP_Text destinationText;
	[SerializeField] private List<GameObject> moneyIconGO;
	[SerializeField] private TMP_Text timeText;
	[SerializeField] private Image icon;
	#endregion

	#region Preview Functions
	public void SetUpOrderPreview(Order order)
	{
		orderAssigned = order;

		SetUpSlot();
	}

	private void SetUpSlot()
	{
		destinationText.text = "" + orderAssigned.OInfo.Recipient.NPCName + " At " + orderAssigned.OInfo.Recipient.AssignedLocation.LocationName;

		ChooseMoneyIcon();

		icon.sprite = orderAssigned.OInfo.Recipient.NPCIcon;

	}

	private void ChooseMoneyIcon()
	{
		foreach (GameObject go in moneyIconGO)
		{
			go.SetActive(false);
		}

		int index = orderAssigned.OInfo.Difficulty - 1;
		moneyIconGO[index].SetActive(true);
	}
	#endregion
}
