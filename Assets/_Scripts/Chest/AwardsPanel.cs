using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class AwardsPanel : MonoBehaviour
{
    [SerializeField] private TMP_Text _text;
    [SerializeField] private ChestAwardData[] _chestAwardsData;
    [SerializeField] private TMP_Text _timerText;
    [SerializeField] private SilverPanel _silverPanel;
    [SerializeField] private ChestButton _chestButton;

    private void OnEnable()
    {
        _text.text = "+" + _chestAwardsData[Saves.Get.GetInt(Keys.ChestLevel)].Coins;
    }

    public void TakeAwards()
    {
        _chestButton.CloseChestButton();

        Saves.Get.AddInt(Keys.MainSilverCount, Saves.Get.GetInt(Keys.MainSilverCount) + _chestAwardsData[Saves.Get.GetInt(Keys.ChestLevel)].Coins);

        Saves.Get.AddInt(Keys.ChestLevel, Saves.Get.GetInt(Keys.ChestLevel) + 1);

        Saves.Get.AddString(Keys.ChestDate, DateTime.Now.ToString());

        if (Saves.Get.GetInt(Keys.ChestLevel) > _chestAwardsData.Length - 1)
        {
            Saves.Get.AddInt(Keys.ChestLevel, _chestAwardsData.Length - 1);
        }
        _timerText.gameObject.SetActive(true);

        _silverPanel.UpdateText();

        gameObject.SetActive(false);
    }
}
