using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ScriptableObject", menuName = "ScriptableObject/EnemySettings")]
public class EnemySettings : ScriptableObject
{
    [SerializeField] private float _speed;
    [SerializeField] private float _health;
    [SerializeField] private int _silverCount;
    [SerializeField] private float _coolDownAfterDamage;
    [SerializeField] private float _turnSpeed;

    public float Speed => _speed;
    public float Health => _health;
    public int SilverCount => _silverCount;
    public float CoolDownAfterDamage => _coolDownAfterDamage;
    public float TurnSpeed => _turnSpeed;
}
