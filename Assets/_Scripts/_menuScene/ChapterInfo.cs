using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ChapterInfo : MonoBehaviour
{
    [SerializeField] private TMP_Text _chapterText;
    [SerializeField] private TMP_Text _levelsText;

    private void Start()
    {
        _chapterText.text = "Chapter: " + (Saves.Get.GetInt(Keys.AvailableChapter) + 1).ToString();

        if (Saves.Get.GetInt(Keys.AvailableChapter) == 0)
        {
            _levelsText.text = "Levels: 7";
        }

        if (Saves.Get.GetInt(Keys.AvailableChapter) == 1)
        {
            _levelsText.text = "Levels: 9";
        }

        if (Saves.Get.GetInt(Keys.AvailableChapter) == 2)
        {
            _levelsText.text = "Levels: 10";
        }
        if (Saves.Get.GetInt(Keys.AvailableChapter) == 3)
        {
            _levelsText.text = "Levels: 8";
        }
    }
}
