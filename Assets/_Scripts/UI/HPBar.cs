using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;

public class HPBar : MonoBehaviour
{
    [SerializeField] private Image _redImage;
    [SerializeField] private TMP_Text _text;
    [SerializeField] private TMP_Text _damageText;
    [SerializeField] private TMP_Text _silverText;

    private float _time = 10;

    private float _silverTime = 10;
    private int _silverCount = 0;

    private void OnEnable()
    {
        if (_text != null)
        {
            _text.text = Saves.Get.GetFloat(Keys.CurrentHealth).ToString();
            _redImage.fillAmount = Saves.Get.GetFloat(Keys.CurrentHealth) / Saves.Get.GetFloat(Keys.TotalHealth);
        }
    }

    private void Start()
    {
        if (_silverText != null)
        {
            Silver.OnSilverCatch += UpdateSilverText;
        }
    }

    private void Update()
    {
        _time += Time.deltaTime;
        _silverTime += Time.deltaTime;

        if (_time > 0.7f && _damageText.gameObject.activeSelf == true)
        {
            _damageText.gameObject.SetActive(false);
        }

        if (_silverText != null) 
        {
            if (_silverTime > 0.9f && _silverText.gameObject.activeSelf == true)
            {
                _silverText.gameObject.SetActive(false);
                _silverCount = 0;
            }
        }

        transform.rotation = Quaternion.Euler(transform.parent.rotation.x, -transform.parent.rotation.y + 225, transform.parent.rotation.z);
    }

    public void UpdateHPBar(float current, float total, float damage = 0)
    {
        transform.DOKill(true);
        transform.DOShakeScale(0.1f, 0.2f, 15, 90, true);

        _redImage.fillAmount = current / total;

        if (_text != null)
        {
            _text.text = current.ToString();
        }

        if (damage != 0)
        {
            _damageText.gameObject.SetActive(true);
        }
        _damageText.text = "-" + damage.ToString();
        _time = 0;
    }

    public void UpdateSilverText()
    {
        _silverCount++;
        _silverTime = 0;
        _silverText.gameObject.SetActive(true);
        _silverText.text = "+" + _silverCount;

        _silverText.transform.DOKill(true);
        _silverText.transform.DOShakeScale(0.4f, 0.4f, 15, 90, true);

    }

    public void Destroy()
    {
        Destroy(gameObject);
    }

    private void DeactivateDamageText()
    {
        _damageText.gameObject.SetActive(false);
    }

    private void OnDisable()
    {
        if (_silverText != null)
        {
            Silver.OnSilverCatch -= UpdateSilverText;
        }
    }
}
