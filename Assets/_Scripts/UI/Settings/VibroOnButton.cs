using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VibroOnButton : MonoBehaviour
{
    [SerializeField] private VibroOffButton _vibroOffButton;

    private void OnEnable()
    {
        if (Saves.Get.GetBool(Keys.Vibration) == true)
        {
            _vibroOffButton.gameObject.SetActive(true);
            gameObject.SetActive(false);
        }
    }

    public void VibroOff()
    {
        Saves.Get.AddBool(Keys.Vibration, true);
        _vibroOffButton.gameObject.SetActive(true);
        gameObject.SetActive(false);
    }
}
