using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Destination", menuName = "New Scriptable Object/New Destination")]
public class DestinationSO : ScriptableObject
{
	#region SO fields
	[SerializeField] private string _destinationName;
	[SerializeField] private difficulty _destinationDifficulty;
	#endregion

	#region Properties
	public string DestinationName
	{
		get { return _destinationName; }
	}
	public difficulty DestinationDifficulty
	{
		get { return _destinationDifficulty; }
	}
	#endregion
}
public enum difficulty
{
	easy,
	medium,
	hard
}