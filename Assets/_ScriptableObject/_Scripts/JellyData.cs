using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ScriptableObject", menuName = "ScriptableObject/JellyData")]
public class JellyData : ScriptableObject
{
    [SerializeField] private float _health;
    [SerializeField] private int _silverCount;

    public float Health => _health;
    public int SilverCount => _silverCount;
}
