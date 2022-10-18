using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EarnedPanel : MonoBehaviour
{
    [SerializeField] private TMP_Text _text;

    private float _silverCount = 0;
    private int _currentLevelSilverCount;

    private void OnEnable()
    {
        _currentLevelSilverCount = Saves.Get.GetInt(Keys.CurrentLevelSilverCount);
    }

    private void FixedUpdate()
    {
        if (_silverCount < _currentLevelSilverCount)
        {
            _text.text = "+" + Mathf.Ceil(_silverCount);
            if (_currentLevelSilverCount - _silverCount < 3)
            {
                _silverCount += 0.10f;
            }
            else if (_currentLevelSilverCount - _silverCount < 5)
            {
                _silverCount += 0.20f;
            }
            else if (_currentLevelSilverCount - _silverCount < 10)
            {
                _silverCount += 0.25f;
            }
            else if (_currentLevelSilverCount - _silverCount < 15)
            {
                _silverCount += 0.50f;
            }
            else if (_currentLevelSilverCount - _silverCount >= 15)
            {
                _silverCount += 1.00f;
            }
        }
    }
}
