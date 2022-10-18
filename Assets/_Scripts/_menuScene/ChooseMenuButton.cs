using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using DG.Tweening;

public class ChooseMenuButton : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera _shopCamera;
    [SerializeField] private CinemachineVirtualCamera _homeCamera;

    [SerializeField] private GameObject _shopPanel;
    [SerializeField] private GameObject _startButton;

    [SerializeField] private GameObject _chapterInfo;

    private float _coolDown = 2;

    private void FixedUpdate()
    {
        _coolDown += Time.fixedDeltaTime;
    }

    public void GoToShop()
    {
        if (_coolDown > 1 && _shopCamera.Priority != 10)
        {
            _shopCamera.Priority = 10;
            _homeCamera.Priority = 0;

            DeactivateStartButton();
            Invoke(nameof(ActivateShopPanel), 1f);

            _coolDown = 0;
        }
    }
    public void GoToHome()
    {
        if (_coolDown > 1 && _shopCamera.Priority != 0)
        {
            _shopCamera.Priority = 0;
            _homeCamera.Priority = 10;

            DeactivateShopPanel();
            Invoke(nameof(ActivateStartButton), 1f);
            _coolDown = 0;
        }
    }

    private void ActivateShopPanel()
    {
        _shopPanel.SetActive(true);

        _shopPanel.transform.DOKill();
        _shopPanel.transform.DOShakeScale(0.25f, 0.2f, 15, 90, true);
    }
    private void DeactivateShopPanel()
    {
        _shopPanel.SetActive(false);
    }

    private void ActivateStartButton()
    {
        _startButton.SetActive(true);
        _chapterInfo.SetActive(true);

        _startButton.transform.DOKill();
        _startButton.transform.DOShakeScale(0.25f, 0.2f, 15, 90, true);
    }
    private void DeactivateStartButton()
    {
        _startButton.SetActive(false);
        _chapterInfo.SetActive(false);
    }
}
