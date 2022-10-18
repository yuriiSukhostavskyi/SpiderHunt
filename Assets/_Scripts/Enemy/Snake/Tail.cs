using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tail : MonoBehaviour
{
    [SerializeField] private Enemy _enemy;

    public Enemy PublicEnemy => _enemy;
}
