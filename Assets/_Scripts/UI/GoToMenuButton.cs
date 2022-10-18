using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToMenuButton : MonoBehaviour
{
    public void GoToMenu()
    {
        Saves.Get.AddInt(Keys.LevelNumber, 0);
        SceneManager.LoadScene(2);
    }
}
