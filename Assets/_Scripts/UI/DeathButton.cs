using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathButton : MonoBehaviour
{
    [SerializeField] private HeroDieAction _heroDieAction;
    [SerializeField] private GameObject _settingsWindow;

    public void Die()
    {
        _settingsWindow.SetActive(false);
        _heroDieAction.Die();
    }
}
