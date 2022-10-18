using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WhiteBar : MonoBehaviour
{
    [SerializeField] private Image _currentImage;
    [SerializeField] private Image _mainImage;

    private void Start()
    {
        _currentImage.fillAmount = _mainImage.fillAmount;
    }

    private void FixedUpdate()
    {
        if (_currentImage.fillAmount > _mainImage.fillAmount)
        {
            _currentImage.fillAmount -= 0.009f; 
        }
    }
}
