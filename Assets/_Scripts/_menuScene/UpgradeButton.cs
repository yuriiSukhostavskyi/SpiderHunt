using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class UpgradeButton : MonoBehaviour
{
    private enum _buttonTypeEnum { Health, Damage, Rate };
    [SerializeField] private _buttonTypeEnum _buttonType;

    [SerializeField] private ShopValue _shopValue;

    [SerializeField] private UpgradePrice _healthPrice;
    [SerializeField] private UpgradePrice _damagePrice;
    [SerializeField] private UpgradePrice _ratePrice;

    [SerializeField] private UpgradeProgressData _healthProgressData;
    [SerializeField] private UpgradeProgressData _damageProgressData;
    [SerializeField] private UpgradeProgressData _rateProgressData;

    [SerializeField] private Transform _health;
    [SerializeField] private Transform _damage;
    [SerializeField] private Transform _rate;

    [SerializeField] private GameObject _hero;
    [SerializeField] private ParticleSystem _upgradeVFX;

    public void PointerDown()
    {
        if (_buttonType == _buttonTypeEnum.Health)
        {
            if (_healthPrice.Price[Saves.Get.GetInt(Keys.TotalHealthLevel)] <= Saves.Get.GetInt(Keys.MainSilverCount))
            {
                Saves.Get.AddInt(Keys.MainSilverCount, Saves.Get.GetInt(Keys.MainSilverCount) - _healthPrice.Price[Saves.Get.GetInt(Keys.TotalHealthLevel)]);
                Saves.Get.AddInt(Keys.TotalHealthLevel, Saves.Get.GetInt(Keys.TotalHealthLevel) + 1);
                Saves.Get.AddFloat(Keys.TotalHealth, _healthProgressData.Value[Saves.Get.GetInt(Keys.TotalHealthLevel)]);
                Saves.Get.AddFloat(Keys.CurrentHealth, _healthProgressData.Value[Saves.Get.GetInt(Keys.TotalHealthLevel)]);

                _health.DOKill(true);
                _health.DOShakeScale(0.3f, 0.9f, 15, 90, true);

                _hero.transform.DOKill(true);
                _hero.transform.DOShakeScale(0.2f, 0.1f, 15, 90, true);

                _upgradeVFX.Play();
            }
        }

        if (_buttonType == _buttonTypeEnum.Damage)
        {
            if (_healthPrice.Price[Saves.Get.GetInt(Keys.DamageLevel)] <= Saves.Get.GetInt(Keys.MainSilverCount))
            {
                Saves.Get.AddInt(Keys.MainSilverCount, Saves.Get.GetInt(Keys.MainSilverCount) - _healthPrice.Price[Saves.Get.GetInt(Keys.DamageLevel)]);
                Saves.Get.AddInt(Keys.DamageLevel, Saves.Get.GetInt(Keys.DamageLevel) + 1);
                Saves.Get.AddFloat(Keys.Damage, _damageProgressData.Value[Saves.Get.GetInt(Keys.DamageLevel)]);

                _damage.DOKill(true);
                _damage.DOShakeScale(0.3f, 0.9f, 15, 90, true);

                _hero.transform.DOKill(true);
                _hero.transform.DOShakeScale(0.2f, 0.1f, 15, 90, true);

                _upgradeVFX.Play();
            }
        }

        if (_buttonType == _buttonTypeEnum.Rate)
        {
            if (_healthPrice.Price[Saves.Get.GetInt(Keys.RateLevel)] <= Saves.Get.GetInt(Keys.MainSilverCount))
            {
                Saves.Get.AddInt(Keys.MainSilverCount, Saves.Get.GetInt(Keys.MainSilverCount) - _healthPrice.Price[Saves.Get.GetInt(Keys.RateLevel)]);
                Saves.Get.AddInt(Keys.RateLevel, Saves.Get.GetInt(Keys.RateLevel) + 1);
                Saves.Get.AddFloat(Keys.Rate, _rateProgressData.Value[Saves.Get.GetInt(Keys.RateLevel)]);

                _rate.DOKill(true);
                _rate.DOShakeScale(0.3f, 0.9f, 15, 90, true);

                _hero.transform.DOKill(true);
                _hero.transform.DOShakeScale(0.2f, 0.1f, 15, 90, true);

                _upgradeVFX.Play();
            }
        }


        _shopValue.UpdateValue();
    }
}
