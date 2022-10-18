using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ScriptableObject", menuName = "ScriptableObject/UpgradePrice")]
public class UpgradePrice : ScriptableObject
{
    [SerializeField] private int[] _price;

    public int[] Price => _price;
}
