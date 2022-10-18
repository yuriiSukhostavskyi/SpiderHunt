using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChapterLoader : MonoBehaviour
{
    [SerializeField] private Chapter[] _chapter;

    private void OnEnable()
    {
        if (Saves.Get.GetInt(Keys.AvailableChapter) > _chapter.Length - 1)
        {
            Saves.Get.AddInt(Keys.AvailableChapter, _chapter.Length - 1);
        }
        Instantiate(_chapter[Saves.Get.GetInt(Keys.AvailableChapter)], transform.position, transform.rotation, transform);
    }
}
