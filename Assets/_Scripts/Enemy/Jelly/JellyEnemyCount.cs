using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JellyEnemyCount : MonoBehaviour
{
    [SerializeField] private EnemyCount _enemyCount;

    private void Start()
    {
        for (int i = 0; i < 15; i++)
        {
            _enemyCount.AddJellyCount();
        }
    }
}
