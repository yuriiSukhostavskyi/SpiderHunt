using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ScriptableObject", menuName = "ScriptableObject/TurretSettings")]
public class TurretSettings : ScriptableObject
{
    [SerializeField] private float _health;
    [SerializeField] private int _silverCount;
    [SerializeField] private float _rateOfFire;

    public float Health => _health;
    public int SilverCount => _silverCount;
    public float RateOfFire => _rateOfFire;
}
