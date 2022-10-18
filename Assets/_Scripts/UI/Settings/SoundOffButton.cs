using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundOffButton : MonoBehaviour
{

    [SerializeField] private SoundOnButton _soundOnButton;
    public void SoundOn()
    {
        Saves.Get.AddBool(Keys.Sound, false);

        _soundOnButton.gameObject.SetActive(true);

        gameObject.SetActive(false);
    }
}
