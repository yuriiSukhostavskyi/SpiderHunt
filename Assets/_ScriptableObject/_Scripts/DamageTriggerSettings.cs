using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ScriptableObject", menuName = "ScriptableObject/DamageTriggerSettings")]
public class DamageTriggerSettings : ScriptableObject
{
    [SerializeField] private float _damage;

    public float Damage => _damage;
}
