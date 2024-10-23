using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameData : MonoBehaviour
{
    #region Class References
    private static GameData _instance;
    #endregion

    #region Private Fields
    [SerializeField] private List<RecipientManager> _gameRecipientNPCS;

    [SerializeField] private List<OrderItemSO> _gameOrderItems;

    [SerializeField] private List<Sprite> rankSprites;

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

   

    public List<OrderItemSO> GameOrderItems
    {
        get { return _gameOrderItems; }
    }

    public List<RecipientManager> GameRecipientNPCs
    {
        get { return _gameRecipientNPCS; }
        set { _gameRecipientNPCS = value; }
    }
    #endregion

    #region Start Up Functions
    public void OnAwake()
    {
        RecipientManager[] temp = FindObjectsOfType<RecipientManager>();

        for (int i =0; i < temp.Length; i++)
        {
            GameRecipientNPCs.Add(temp[i]);
        }
    }
    #endregion


    public Sprite GetRankIcon(int rank)
    {
        return rankSprites[rank];
    }
}
