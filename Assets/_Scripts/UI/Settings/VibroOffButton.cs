using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VibroOffButton : MonoBehaviour
{

    [SerializeField] private VibroOnButton _vibroOnButton;
    public void VibroOn()
    {
        Saves.Get.AddBool(Keys.Vibration, false);

        _vibroOnButton.gameObject.SetActive(true);

        gameObject.SetActive(false);
    }
}
