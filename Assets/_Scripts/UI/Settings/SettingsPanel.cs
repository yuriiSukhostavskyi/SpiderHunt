using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsPanel : MonoBehaviour
{
    [SerializeField] private GameObject _settingsWindow;
    public void CloseSettingsPanel()
    {
        _settingsWindow.SetActive(false);
    }

    public void OpenSettingsPanel()
    {
        _settingsWindow.SetActive(true);
    }
}
