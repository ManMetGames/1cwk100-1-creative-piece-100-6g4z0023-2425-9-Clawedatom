using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameData : MonoBehaviour
{
    #region Class References
    private static GameData _instance;
    #endregion

    #region Private Fields
    [SerializeField] private List<NPCSO> _gameRecipientNPCS;
    #endregion

    #region Properties

    public static GameData Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindAnyObjectByType<GameData>();

                if (_instance == null)
                {
                    Debug.LogError("GameData has not been assigned");
                    Application.Quit();
                }
            }
            return _instance;

        }
    }

    public List<NPCSO> GameRecipientNPCS
    {
        get { return _gameRecipientNPCS; }
        set { _gameRecipientNPCS = value; }
    }
    #endregion

    
}
