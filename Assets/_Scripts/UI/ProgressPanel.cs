using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;

public class ProgressPanel : MonoBehaviour
{

    public delegate void OnActivatePortalDelegate();
    public static event OnActivatePortalDelegate OnActivatePortal;

    [SerializeField] private Image _progressImage;
    [SerializeField] private TMP_Text _text;
    [SerializeField] private BonusLevelTextpanel _bonusLevelTextPanel;
    [SerializeField] private BonusLevelTextpanel _bossLevelTextPanel;
    [SerializeField] private LevelLoader _levelLoader;

    [SerializeField] private HPBar _heroHPBar;

    private float _enemyCount;

    private float _startEnemyCount;
    private float _progress;

    private void OnEnable()
    {
        if (Saves.Get.GetInt(Keys.LevelNumber) == _levelLoader.ListOfChapters.Chapters[Saves.Get.GetInt(Keys.CurrentChapter)].Levels.Count - 2)
        {
            _bossLevelTextPanel.gameObject.SetActive(true);
        }
        if (Saves.Get.GetInt(Keys.LevelNumber) == _levelLoader.ListOfChapters.Chapters[Saves.Get.GetInt(Keys.CurrentChapter)].Levels.Count - 1)
        {
            _bonusLevelTextPanel.gameObject.SetActive(true);
        }

        _text.text = "Level " + (Saves.Get.GetInt(Keys.LevelNumber) + 1).ToString() + "/" + _levelLoader.ListOfChapters.Chapters[Saves.Get.GetInt(Keys.CurrentChapter)].Levels.Count;

        EnemyCount.OnAddEnemy += AddEnemyCount;
        EnemyCount.OnDecreaseEnemy += DecreaseEnemyCount;
    }

    private void Start()
    {
        Invoke(nameof(StartCount), 0.5f);
    }

    private void StartCount()
    {
        _startEnemyCount = _enemyCount;

        UpdateProgress();
    }

    private void AddEnemyCount()
    {
        _enemyCount++;
    }

    private void DecreaseEnemyCount()
    {
        _enemyCount--;
        UpdateProgress();
    }

    private void UpdateProgress()
    {

        transform.DOKill(true);
        transform.DOShakeScale(0.25f, 0.1f, 15, 90, true);

        if (_enemyCount < 0)
        {
            _enemyCount = 0;
        }

        _progress = 1 - (_enemyCount / _startEnemyCount);

        if (_startEnemyCount == 0)
        {
            _progress = 1;
        }

        _progressImage.fillAmount = _progress;

        if (_progress == 1)
        {
            Invoke(nameof(ActivatePortal), 0.15f);

            TimeScaler.Instance.TimeScaleAction();
        }
    }

    private void ActivatePortal()
    {
        if (OnActivatePortal != null)
        {
            if (_enemyCount == 0)
            {
                OnActivatePortal();
            }
        }
    }

    private void OnDisable()
    {
        EnemyCount.OnAddEnemy -= AddEnemyCount;
        EnemyCount.OnDecreaseEnemy -= DecreaseEnemyCount;
    }
}
