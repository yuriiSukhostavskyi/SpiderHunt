using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOption : MonoBehaviour
{
    [SerializeField] private int _chapter;
    [SerializeField] private int _levelNumber;
    [SerializeField] private int _coins;

    [SerializeField] private float _health;
    [SerializeField] private float _damage;
    [SerializeField] private float _rate;
    public void SetLevel()
    {
        Saves.Get.AddInt(Keys.CurrentChapter, _chapter - 1);
        Saves.Get.AddInt(Keys.AvailableChapter, _chapter - 1);
        Saves.Get.AddInt(Keys.LevelNumber, _levelNumber - 1);
        Saves.Get.AddInt(Keys.MainSilverCount, _coins);

        Saves.Get.AddFloat(Keys.CurrentHealth, _health);
        Saves.Get.AddFloat(Keys.TotalHealth, _health);
        Saves.Get.AddFloat(Keys.Damage, _damage);
        Saves.Get.AddFloat(Keys.Rate, _rate);

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
