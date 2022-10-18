using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ContinueLevel : MonoBehaviour
{
    private void Start()
    {

        if (Saves.Get.GetInt(Keys.LevelNumber) != 0)
        {
            SceneManager.LoadScene(3);
        }
    }
}
