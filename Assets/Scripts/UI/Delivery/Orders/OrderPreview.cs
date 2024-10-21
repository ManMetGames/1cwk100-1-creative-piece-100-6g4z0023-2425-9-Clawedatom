using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrderPreview : MonoBehaviour
{
	#region Private Fields
	[SerializeField] private Order orderAssigned;
	#endregion

	#region Preview Functions
	public void SetUpOrderPreview(Order order)
	{
		orderAssigned = order;
	}
	#endregion
}
