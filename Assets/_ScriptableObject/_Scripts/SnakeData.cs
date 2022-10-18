using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ScriptableObject", menuName = "ScriptableObject/SnakeData")]
public class SnakeData : ScriptableObject
{
    [SerializeField] private float _health;
    [SerializeField] private int _silverCount;

    public float Health => _health;
    public int SilverCount => _silverCount;
}
