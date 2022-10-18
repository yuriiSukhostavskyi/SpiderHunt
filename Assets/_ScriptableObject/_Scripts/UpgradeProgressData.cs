using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ScriptableObject", menuName = "ScriptableObject/UpgradeProgressData")]
public class UpgradeProgressData : ScriptableObject
{
    [SerializeField] private float[] _value;

    public float[] Value => _value;
}
