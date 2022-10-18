using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Lofelt.NiceVibrations;

public class Vibration : MonoBehaviour
{
    public static Vibration Instance { get; private set; }

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
    }

    private bool TryToMakeVibration()
    {
        if (Saves.Get.GetBool(Keys.Vibration) == false)
        {
            return true;
        }
        else
            return false;
    }

    public void ShortVibrate()
    {
        if (TryToMakeVibration())
        {
            //HapticPatterns.PlayConstant(0.04f, 0.15f, 0.015f);
            HapticPatterns.PlayEmphasis(0.2f, 0.45f);
        }
    }
    public void MiddleVibrate()
    {
        if (TryToMakeVibration())
        {
            //HapticPatterns.PlayConstant(0.05f, 0.2f, 0.05f);
            HapticPatterns.PlayEmphasis(0.25f, 0.75f);
        }
    }
    public void BigVibrate()
    {
        if (TryToMakeVibration())
        {
            //HapticPatterns.PlayConstant(0.1f, 0.3f, 0.4f);
            HapticPatterns.PlayEmphasis(0.3f, 1f);
        }
    }
}
