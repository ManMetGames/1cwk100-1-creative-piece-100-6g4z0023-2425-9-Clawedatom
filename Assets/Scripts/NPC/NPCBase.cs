using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCBase : MonoBehaviour, Interactable
{
	#region Private Fields
	[SerializeField] private NPCType _typeOfNPC;
	#endregion

	#region Properties
	public NPCType TypeOfNPC
	{
		get { return _typeOfNPC; }
	}
	#endregion

	#region NPC Base functions
	public virtual void OnInteract(PlayerManager playerManager)
	{
		switch(TypeOfNPC)
		{
			case (NPCType.recipient):
			{
				//open recipient ui
				playerManager.NPC_RecipientInteract();
				break;
			}
            case (NPCType.boss):
            {
				playerManager.NPC_BossInteract();
                break;
            }
			case (NPCType.world):
			{
				//nothing
				playerManager.NPC_WorldInteract();
				break;
			}
        }

		//face player
	}
	#endregion
}
public enum NPCType
{
	recipient,
	boss,
	world
}