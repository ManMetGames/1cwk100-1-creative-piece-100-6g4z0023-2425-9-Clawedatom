using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New NPC", menuName = "New Scriptable Object/  New NPC")]
public class NPCSO : ScriptableObject
{
	#region SO Fields
	[SerializeField] private string _npcName;

	#endregion

	#region Properties
	public string NPCName
	{
		get { return _npcName; }
	}
	#endregion
}
