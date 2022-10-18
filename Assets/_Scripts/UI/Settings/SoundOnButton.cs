using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundOnButton : MonoBehaviour
{
    [SerializeField] private SoundOffButton _soundOffButton;

    private void OnEnable()
    {
        if (Saves.Get.GetBool(Keys.Sound) == true)
        {
            _soundOffButton.gameObject.SetActive(true);
            gameObject.SetActive(false);
        }
    }

    public void SoundOff()
    {
        Saves.Get.AddBool(Keys.Sound, true);
        _soundOffButton.gameObject.SetActive(true);
        gameObject.SetActive(false);
    }
}
