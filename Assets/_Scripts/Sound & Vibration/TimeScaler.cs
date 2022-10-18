using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TimeScaler : MonoBehaviour
{
    public static TimeScaler Instance { get; private set; }

    private float _timeScale;

    public void Awake()
    {
        if (!Instance)
        {
            Instance = this;
            DontDestroyOnLoad(target: this);
        }
        else
        {
            Destroy(gameObject);
        }

        Time.timeScale = 1f;
    }

    private void Update()
    {
        if (Time.timeScale < 1f)
        {
            Time.timeScale *= 1.015f;
        }

        if (Time.timeScale > 1f)
        {
            Time.timeScale = 1f;
        }
    }

    public void TimeScaleAction()
    {
        Time.timeScale = 0.25f;
    }
}
