using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Location", menuName = "New Scriptable Object/ New Location")]
public class LocationSO : ScriptableObject
{
    [SerializeField] private string _locationName;

    public string LocationName
    {
        get { return _locationName; }
    }
}
