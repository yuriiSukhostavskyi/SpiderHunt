using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShopValue : MonoBehaviour
{
    [SerializeField] private SilverPanel _silverPanel;

    [SerializeField] private TMP_Text _health;
    [SerializeField] private TMP_Text _damage;
    [SerializeField] private TMP_Text _rate;

    [SerializeField] private UpgradePrice _healthDataPrice;
    [SerializeField] private UpgradePrice _damageDataPrice;
    [SerializeField] private UpgradePrice _rateDataPrice;

    [SerializeField] private TMP_Text _healthPrice;
    [SerializeField] private TMP_Text _damagePrice;
    [SerializeField] private TMP_Text _ratePrice;

    [SerializeField] private UpgradeProgressData _healthProgressData;
    [SerializeField] private UpgradeProgressData _damageProgressData;
    [SerializeField] private UpgradeProgressData _rateProgressData;

    private void Start()
    {
        UpdateValue();
    }
    public void UpdateValue()
    {
        _silverPanel.UpdateText();

        _health.text = _healthProgressData.Value[Saves.Get.GetInt(Keys.TotalHealthLevel)].ToString();
        _damage.text = _damageProgressData.Value[Saves.Get.GetInt(Keys.DamageLevel)].ToString();
        _rate.text = _rateProgressData.Value[Saves.Get.GetInt(Keys.RateLevel)].ToString();

        _healthPrice.text = _healthDataPrice.Price[Saves.Get.GetInt(Keys.TotalHealthLevel)].ToString();
        _damagePrice.text = _damageDataPrice.Price[Saves.Get.GetInt(Keys.DamageLevel)].ToString();
        _ratePrice.text = _rateDataPrice.Price[Saves.Get.GetInt(Keys.RateLevel)].ToString();

        ChangeTextColor();
    }

    private void ChangeTextColor()
    {
        if (_healthDataPrice.Price[Saves.Get.GetInt(Keys.TotalHealthLevel)] <= Saves.Get.GetInt(Keys.MainSilverCount))
        {
            _healthPrice.faceColor = Color.green;
        }
        if (_healthDataPrice.Price[Saves.Get.GetInt(Keys.TotalHealthLevel)] > Saves.Get.GetInt(Keys.MainSilverCount))
        {
            _healthPrice.faceColor = Color.grey;
        }

        if (_damageDataPrice.Price[Saves.Get.GetInt(Keys.DamageLevel)] <= Saves.Get.GetInt(Keys.MainSilverCount))
        {
            _damagePrice.faceColor = Color.green;
        }
        if (_damageDataPrice.Price[Saves.Get.GetInt(Keys.DamageLevel)] > Saves.Get.GetInt(Keys.MainSilverCount))
        {
            _damagePrice.faceColor = Color.grey;
        }

        if (_rateDataPrice.Price[Saves.Get.GetInt(Keys.RateLevel)] <= Saves.Get.GetInt(Keys.MainSilverCount))
        {
            _ratePrice.faceColor = Color.green;
        }
        if (_rateDataPrice.Price[Saves.Get.GetInt(Keys.RateLevel)] > Saves.Get.GetInt(Keys.MainSilverCount))
        {
            _ratePrice.faceColor = Color.grey;
        }

    }
}
