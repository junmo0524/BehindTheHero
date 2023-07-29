using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Status Data", menuName = "Custom/MaxStatus Data")]
public class MaxStatusData : ScriptableObject
{
    [SerializeField]
    public int MaxLevel;
    [SerializeField]
    public int MaxStatus;
}
