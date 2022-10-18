using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ScriptableObject", menuName = "ScriptableObject/TimeForChestData")]
public class TimeForChestData : ScriptableObject
{
    [SerializeField] private int _minute;

    public int Minute => _minute;
}
