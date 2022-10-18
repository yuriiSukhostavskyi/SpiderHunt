using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class ChestButton : MonoBehaviour
{
    [SerializeField] private TMP_Text _text;
    [SerializeField] private TimeForChestData[] _timeFoChestData;
    [SerializeField] private Animator _buttonAnimator;
    [SerializeField] private AwardsPanel _awardsPanel;

    private TimeSpan _timeSpane;
    private float _secondsAfterChestDate;
    private float _deltaTime;
    private bool ChestOpend;

    private void OnEnable()
    {
        if (Saves.Get.GetString(Keys.ChestDate).Length < 2)
        {
            Saves.Get.AddString(Keys.ChestDate, DateTime.Now.ToString());
        }
    }

    public void PointerDown()
    {
        if (ChestOpend == true)
        {

            _awardsPanel.gameObject.SetActive(true);
        }
    }

    public void CloseChestButton()
    {
        ChestOpend = false;
        _buttonAnimator.SetTrigger("Close");
    }

    private void FixedUpdate()
    {
        if (ChestOpend == false)
        {
            _timeSpane = (DateTime.Now - DateTime.Parse(Saves.Get.GetString(Keys.ChestDate)));
            _secondsAfterChestDate = _timeSpane.Minutes * 60 + _timeSpane.Seconds;
            _deltaTime = _timeFoChestData[Saves.Get.GetInt(Keys.ChestLevel)].Minute * 60 - _secondsAfterChestDate;

            _text.text = Mathf.Floor(_deltaTime / 60).ToString() + ":" + (_deltaTime - Mathf.Floor(_deltaTime / 60) * 60);

            if (_deltaTime - Mathf.Floor(_deltaTime / 60) * 60 < 10) // добавляем 0
            {
                _text.text = Mathf.Floor(_deltaTime / 60).ToString() + ":0" + (_deltaTime - Mathf.Floor(_deltaTime / 60) * 60);
            }
        }


        if (_deltaTime < 1 && ChestOpend == false)
        {
            OpenChest();
        }
    }

    public void OpenChest()
    {
        ChestOpend = true;
        _buttonAnimator.SetTrigger("Open");
        _text.gameObject.SetActive(false);
    }
}
