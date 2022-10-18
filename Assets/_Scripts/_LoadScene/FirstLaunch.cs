using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class FirstLaunch : MonoBehaviour
{
    [SerializeField] private UpgradeProgressData _healthData;
    [SerializeField] private UpgradeProgressData _rateData;
    [SerializeField] private UpgradeProgressData _damageData;

    private void Start()
    {
        if (Saves.Get.GetInt(Keys.FirstLaunch) == 0)
        {
            Saves.Get.AddInt(Keys.FirstLaunch, 1);

            Saves.Get.AddFloat(Keys.TotalHealth, _healthData.Value[Saves.Get.GetInt(Keys.TotalHealthLevel)]);
            Saves.Get.AddFloat(Keys.CurrentHealth, _healthData.Value[Saves.Get.GetInt(Keys.TotalHealthLevel)]);

            Saves.Get.AddFloat(Keys.Rate, _rateData.Value[Saves.Get.GetInt(Keys.RateLevel)]);

            Saves.Get.AddFloat(Keys.Damage, _damageData.Value[Saves.Get.GetInt(Keys.DamageLevel)]);

            Saves.Get.AddString(Keys.ChestDate, DateTime.Now.ToString());

            SceneManager.LoadScene(3);
        }
        else
        {
            SceneManager.LoadScene(2);
        }
    }
}
