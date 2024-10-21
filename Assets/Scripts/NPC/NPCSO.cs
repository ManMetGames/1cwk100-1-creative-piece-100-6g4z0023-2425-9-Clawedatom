using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New NPC", menuName = "New Scriptable Object/  New NPC")]
public class NPCSO : ScriptableObject
{
	#region SO Fields
	[SerializeField] private string _npcName;

	[SerializeField] private Sprite _npcIcon;

	public LocationSO _assignedLocation;

	//[SerializeField] private 

	#endregion

	#region Properties
	public string NPCName
	{
		get { return _npcName; }
	}
	public Sprite NPCIcon
	{
		get { return _npcIcon; }
	}

	public LocationSO AssignedLocation
	{
		get { return _assignedLocation; }
	}
	#endregion
}
