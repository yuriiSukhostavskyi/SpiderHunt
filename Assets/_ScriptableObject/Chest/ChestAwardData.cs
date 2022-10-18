using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ScriptableObject", menuName = "ScriptableObject/ChestAwardData")]
public class ChestAwardData : ScriptableObject
{
    [SerializeField] private int _coins;

    public int Coins => _coins;
}
