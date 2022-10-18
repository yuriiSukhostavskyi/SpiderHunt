using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBarYellow : MonoBehaviour
{
    [SerializeField] private Image _whiteImage;
    [SerializeField] private Image _yellowImage;

    private void FixedUpdate()
    {
        _yellowImage.fillAmount += (_whiteImage.fillAmount - _yellowImage.fillAmount) / 10;
    }
}
