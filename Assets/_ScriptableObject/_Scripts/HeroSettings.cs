using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ScriptableObject", menuName = "ScriptableObject/HeroSettings")]
public class HeroSettings : ScriptableObject
{
    [SerializeField] private float _bulletSpeed;

    public float BulletSpeed => _bulletSpeed;
}
