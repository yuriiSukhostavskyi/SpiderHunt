using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class StartButton : MonoBehaviour
{
    [SerializeField] private GameObject _location;
    [SerializeField] private Canvas _mainCanvas;

    public void PointerDown()
    {
        Saves.Get.AddInt(Keys.CurrentChapter, Saves.Get.GetInt(Keys.AvailableChapter));
        Saves.Get.AddInt(Keys.LevelNumber, 0);
        _mainCanvas.gameObject.SetActive(false);

        _location.transform.DOMoveY(-11, 2.15f);

        Invoke(nameof(LoadScene), 0.65f);
    }

    private void LoadScene()
    {
        SceneManager.LoadScene(3);
    }
}
