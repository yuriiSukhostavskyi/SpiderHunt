using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using DG.Tweening;

[System.Serializable]
public class LevelsList
{
    public List<Level> Levels;
}

[System.Serializable]
public class ChaptersList
{
    [NonReorderable]
    public List<LevelsList> Chapters;
}

public class LevelLoader : MonoBehaviour
{

    [SerializeField] private ChaptersList _listOfChapters = new ChaptersList();
    [SerializeField] private NavMeshSurface _navMeshSurface;
    [SerializeField] private GameObject _portalVFX;
    [SerializeField] private Joystick _joystick;
    [SerializeField] private Hero _hero;
    [SerializeField] private HPBar _heroHPBar;
    [SerializeField] private GameObject _fakeJoystick;
    [SerializeField] private Renderer[] _heroRenderers;

    private Level _newLevel;

    public ChaptersList ListOfChapters => _listOfChapters;
    public Level NewLevel => _newLevel;

    private void Start()
    {
        Time.timeScale = 1f;

        LoadNextLevel();
    }

    public void LoadNextLevel()
    {
        Invoke(nameof(ActivateVFX), 1.8f);
        Invoke(nameof(ActivateHero), 2.0f);
        Invoke(nameof(SetLevelStartedEvent), 2.0f);

        _navMeshSurface.RemoveData();

        _newLevel = Instantiate(_listOfChapters.Chapters[Saves.Get.GetInt(Keys.CurrentChapter)].Levels[Saves.Get.GetInt(Keys.LevelNumber)], transform.position - Vector3.up * 11, transform.rotation, transform);

        _newLevel.transform.DOMoveY(transform.position.y, 1.35f);

        Invoke(nameof(BuildNavMesh), 1.4f);
    }

    private void BuildNavMesh()
    {
        _navMeshSurface.BuildNavMesh();
    }

    private void ActivateVFX()
    {
        //Instantiate(_portalVFX, transform.position - Vector3.up * 1.5f, Quaternion.Euler(90, 0, 0));
        Sound.Instance.StartSound();
        Vibration.Instance.MiddleVibrate();
    }

    private void ActivateHero()
    {
        _hero.gameObject.SetActive(true);
        _heroHPBar.gameObject.SetActive(true);
        _joystick.gameObject.SetActive(true);

        _fakeJoystick.SetActive(true);
        //_fakeJoystick.transform.DOKill(true);
        //_fakeJoystick.transform.DOShakeScale(0.5f, 0.25f, 15, 90, true);
    }

    private void SetLevelStartedEvent()
    {
        GAInstance.Instance.LevelStartedEvent(Saves.Get.GetInt(Keys.CurrentChapter) + 1, Saves.Get.GetInt(Keys.LevelNumber) + 1);
    }
}
