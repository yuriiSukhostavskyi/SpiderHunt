using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using DG.Tweening;

public class FinishAction : MonoBehaviour
{
    [SerializeField] private GameObject _defeatPanel;
    [SerializeField] private GameObject _victoryPanel;
    [SerializeField] private GameObject _fakeJoystick;
    [SerializeField] private Joystick _joystick;
    [SerializeField] private Hero _hero;
    [SerializeField] private PhysicHeroMover _physicHeroMover;
    [SerializeField] private SilverPanel _silverPanel;
    [SerializeField] private LevelLoader _levelLoader;
    [SerializeField] private Collider _mainPlatformCollider;

    public enum FinishEnum { VICTORY, DEFEAT }

    public delegate void OnFinishedDelegate();
    public static event OnFinishedDelegate OnFinished;

    private bool _finishBool = false;
    public bool FinishBool => _finishBool;

    public void Finish(FinishEnum finishEnum)
    {
        _hero.gameObject.SetActive(false);
        _physicHeroMover.gameObject.SetActive(false);
        _fakeJoystick.SetActive(false);

        _finishBool = true;

        if (OnFinished != null)
        {
            OnFinished();
        }

        Time.timeScale = 1f;

        if (finishEnum == FinishEnum.DEFEAT)
        {
            GAInstance.Instance.LevelFailEvent(Saves.Get.GetInt(Keys.CurrentChapter) + 1, Saves.Get.GetInt(Keys.LevelNumber) + 1);

            //Debug.LogError("Level fail: " + (Saves.Get.GetInt(Keys.TotalLevelNumber) + 1));

            Invoke(nameof(DefeatPanelActivator), 1.5f);
        }

        if (finishEnum == FinishEnum.VICTORY)
        {
            GAInstance.Instance.LevelCompleteEvent(Saves.Get.GetInt(Keys.CurrentChapter) + 1, Saves.Get.GetInt(Keys.LevelNumber) + 1);
            //Debug.LogError("Level complete: " + (Saves.Get.GetInt(Keys.TotalLevelNumber) + 1));

            _silverPanel.SaveCoins();

            Saves.Get.AddInt(Keys.LevelNumber, Saves.Get.GetInt(Keys.LevelNumber) + 1);

            Invoke(nameof(VictoryPanelActivator), 1.5f);
        }

        Invoke(nameof(MoveLevelDown), 1f);
    }

    private void MoveLevelDown()
    {
        _mainPlatformCollider.enabled = false;
        _levelLoader.NewLevel.transform.DOMoveY(-11, 2.15f);
    }

    private void DefeatPanelActivator()
    {
        _defeatPanel.SetActive(true);

        _defeatPanel.transform.localScale = new Vector3(1, 1, 1);
        _defeatPanel.transform.DOShakeScale(0.25f, 0.2f, 15, 90, true);
    }

    private void VictoryPanelActivator()
    {
        _victoryPanel.SetActive(true);

        _victoryPanel.transform.localScale = new Vector3(1, 1, 1);
        _victoryPanel.transform.DOShakeScale(0.25f, 0.2f, 15, 90, true);
    }
}
