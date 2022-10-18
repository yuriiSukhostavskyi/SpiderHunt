using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;

public class SilverPanel : MonoBehaviour
{
    [SerializeField] private TMP_Text _text;
    [SerializeField] private Transform _panel;

    private void Start()
    {
        Silver.OnSilverCatch += AddSilver;

        Saves.Get.AddInt(Keys.CurrentLevelSilverCount, 0);

        _text.text = Saves.Get.GetInt(Keys.MainSilverCount).ToString();

        if (Saves.Get.GetInt(Keys.MainSilverCount) > 0)
        {
            _panel.gameObject.SetActive(true);
        }
    }

    private void AddSilver()
    {

        if (_panel.gameObject.activeSelf == false)
        {
            _panel.gameObject.SetActive(true);
        }

        Saves.Get.AddInt(Keys.CurrentLevelSilverCount, Saves.Get.GetInt(Keys.CurrentLevelSilverCount) + 1);

        //Saves.Get.AddInt(Keys.MainSilverCount, Saves.Get.GetInt(Keys.MainSilverCount) + 1);

        UpdateText();
    }

    public void UpdateText()
    {
        _text.text = (Saves.Get.GetInt(Keys.MainSilverCount) + Saves.Get.GetInt(Keys.CurrentLevelSilverCount)).ToString();

        _panel.DOKill(true);

        _panel.localScale = new Vector3(1, 1, 1);
        _panel.DOShakeScale(0.25f, 0.15f, 15, 90, true);
    }

    public void SaveCoins()
    {
        Saves.Get.AddInt(Keys.MainSilverCount, Saves.Get.GetInt(Keys.MainSilverCount) + Saves.Get.GetInt(Keys.CurrentLevelSilverCount));
    }

    private void OnDisable()
    {
        Silver.OnSilverCatch -= AddSilver;
    }
}
