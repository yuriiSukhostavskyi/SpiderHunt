using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCount : MonoBehaviour
{
    public delegate void OnAddEnemyDelegate();
    public static event OnAddEnemyDelegate OnAddEnemy;

    public delegate void OnDecreaseEnemyDelegate();
    public static event OnDecreaseEnemyDelegate OnDecreaseEnemy;


    private void Start()
    {
        if (Saves.Get.GetInt(Keys.CurrentChapter) == 2 && Saves.Get.GetInt(Keys.LevelNumber) == 8)
        {
        }
        else
        {
            if (OnAddEnemy != null)
            {
                OnAddEnemy();
            }
        }
    }

    public void AddJellyCount()
    {
        if (OnAddEnemy != null)
        {
            OnAddEnemy();
        }
    }

    private void OnDisable()
    {
        if (OnDecreaseEnemy != null)
        {
            OnDecreaseEnemy();
        }
    }
}
