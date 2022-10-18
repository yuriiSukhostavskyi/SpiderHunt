using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class RetryWithMoney : MonoBehaviour
{
    [SerializeField] private TMP_Text _text;

    private void OnEnable()
    {
        if (Saves.Get.GetInt(Keys.MainSilverCount) < 50)
        {
            _text.faceColor = Color.grey;
        }
        else
        {
            _text.faceColor = Color.green;
        }
    }

    public void PointerDown()
    {
        if (Saves.Get.GetInt(Keys.MainSilverCount) >= 50)
        {
            Saves.Get.AddInt(Keys.MainSilverCount, Saves.Get.GetInt(Keys.MainSilverCount) - 50);

            Saves.Get.AddFloat(Keys.CurrentHealth, Saves.Get.GetFloat(Keys.TotalHealth));

            SceneManager.LoadScene(3);
        }
    }
}
