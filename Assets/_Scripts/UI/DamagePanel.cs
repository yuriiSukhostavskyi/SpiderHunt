using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DamagePanel : MonoBehaviour
{
    [SerializeField] private Image _damageImage;

    private float _alpha = 0;

    public void ShowDamage()
    {
        _alpha = 0.7f;
    }

    private void Update()
    {
        _alpha -= Time.deltaTime;

        if (_alpha < 0)
        {
            _alpha = 0;
        }

        _damageImage.color = new Color(_damageImage.color.r, _damageImage.color.g, _damageImage.color.b, _alpha);
    }
}
