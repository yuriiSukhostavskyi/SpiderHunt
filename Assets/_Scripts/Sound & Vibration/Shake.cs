using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class Shake : MonoBehaviour
{
    public static Shake Instance { get; private set; }

    [SerializeField] private CinemachineVirtualCamera _virtualCamera;
    private CinemachineBasicMultiChannelPerlin _virtualCameraNoise;

   

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

        _virtualCameraNoise = _virtualCamera.GetCinemachineComponent<Cinemachine.CinemachineBasicMultiChannelPerlin>();
    }

    private void Update()
    {
        if (_virtualCameraNoise.m_AmplitudeGain > 0f)
        {
            _virtualCameraNoise.m_AmplitudeGain -= 30 * Time.deltaTime;
        }
        if (_virtualCameraNoise.m_AmplitudeGain < 0f)
        {
            _virtualCameraNoise.m_AmplitudeGain = 0f;
        }
    }

    public void ShakeAction()
    {
        _virtualCameraNoise.m_AmplitudeGain = 5;
    }
}
