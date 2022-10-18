using GameAnalyticsSDK;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GAInstance : MonoBehaviour
{
    public static GAInstance Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;

            GameAnalytics.Initialize();
        }

        DontDestroyOnLoad(this);
    }

    public void LevelStartedEvent(int chapterNumber, int levelNumber)
    {
            GameAnalytics.NewProgressionEvent(GAProgressionStatus.Start, $"Started_chapter_ {chapterNumber} _level_ {levelNumber}");
            GameAnalytics.NewDesignEvent($"Started_chapter_ {chapterNumber} _level_ {levelNumber}");

            //Debug.LogError("Started");
    }

    public void LevelCompleteEvent(int chapterNumber, int levelNumber)
    {
            GameAnalytics.NewProgressionEvent(GAProgressionStatus.Complete, $"Complete_chapter_ {chapterNumber} _level_ {levelNumber}");
            GameAnalytics.NewDesignEvent($"Complete_chapter_ {chapterNumber} _level_ {levelNumber}");

            //Debug.LogError("Complete");

        ScoresCountEvent();
    }

    public void LevelFailEvent(int chapterNumber, int levelNumber)
    {
            GameAnalytics.NewProgressionEvent(GAProgressionStatus.Fail, $"Fail_chapter_ {chapterNumber} _level_ {levelNumber}");
            GameAnalytics.NewDesignEvent($"Fail_chapter_ {chapterNumber} _level_ {levelNumber}");

            //Debug.LogError("Fail");
    }

    public void ScoresCountEvent()
    {
        int count = 0;
        int totalCount = 0;

        if (PlayerPrefs.HasKey("Scores") == true)
        {
            count = PlayerPrefs.GetInt("Scores");
            GameAnalytics.NewResourceEvent(GAResourceFlowType.Source, "Scores", (float)count, "Count", "CurrentScores");
        }

        if (PlayerPrefs.HasKey("TotalScores") == true)
        {
            totalCount = PlayerPrefs.GetInt("TotalScores");
            GameAnalytics.NewResourceEvent(GAResourceFlowType.Source, "Scores", (float)totalCount, "Count", "TotalScores");
        }
    }
}
