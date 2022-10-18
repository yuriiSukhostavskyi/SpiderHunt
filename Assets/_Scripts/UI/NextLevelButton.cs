using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class NextLevelButton : MonoBehaviour
{
    [SerializeField] private LevelLoader _levelLoader;
    [SerializeField] private TMP_Text _text;

    private void OnEnable()
    {
        if (Saves.Get.GetInt(Keys.LevelNumber) == _levelLoader.ListOfChapters.Chapters[Saves.Get.GetInt(Keys.CurrentChapter)].Levels.Count)
        {
            _text.text = "HOME";
        }
    }

    public void Next()
    {
        if (Saves.Get.GetInt(Keys.LevelNumber) == _levelLoader.ListOfChapters.Chapters[Saves.Get.GetInt(Keys.CurrentChapter)].Levels.Count)
        {
            Saves.Get.AddInt(Keys.LevelNumber, 0);
            Saves.Get.AddInt(Keys.AvailableChapter, Saves.Get.GetInt(Keys.CurrentChapter) + 1);

            SceneManager.LoadScene(2);
        }
        else
        {
            SceneManager.LoadScene(3);
        }
    }
}
