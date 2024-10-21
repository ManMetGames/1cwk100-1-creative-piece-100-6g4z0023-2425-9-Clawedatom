using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCManager : NPCBase
{
    #region Class References

    #endregion

    #region Private Fields
    [SerializeField] private NPCSO _npc;
    #endregion

    #region Properties
    public NPCSO NPC
    {
        get { return _npc; }
        set { _npc = value; }
    }
    
    #endregion

    #region Start Up
    public void OnAwake()
    {

    }
    public void OnStart()
    {

    }
    #endregion

    #region Update Functions

    public void OnUpdate()
    {

    }
    #endregion

    #region NPC Functions
    public override void OnInteract(PlayerManager playerManager)
    {
        base.OnInteract(playerManager);

    }
    #endregion
}
