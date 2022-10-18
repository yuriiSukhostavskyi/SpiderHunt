using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound : MonoBehaviour
{
    public static Sound Instance { get; private set; }

    public AudioSource[] _audioSourceArray;

    private float _silverCoolDown = 0;

    private void Update()
    {
        _silverCoolDown += Time.deltaTime;
    }

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

    private bool TryToMakeSound()
    {
        if (Saves.Get.GetBool(Keys.Sound) == false)
        {
            return true;
        }
        else
            return false;
    }

    public void SilverSound()
    {
        if (TryToMakeSound())
        {
            _audioSourceArray[0].Play();
        }
    }

    public void ShootSound()
    {
        if (TryToMakeSound())
        {
            _audioSourceArray[1].Play();
        }
    }

    public void ExplosionSound()
    {
        if (TryToMakeSound())
        {
            _audioSourceArray[2].Play();
        }
    }

    public void WallSound()
    {
        if (TryToMakeSound())
        {
            _audioSourceArray[3].Play();
        }
    }

    public void PortalSound()
    {
        if (TryToMakeSound())
        {
            _audioSourceArray[4].Play();
        }
    }

    public void StartSound()
    {
        if (TryToMakeSound())
        {
            _audioSourceArray[5].Play();
        }
    }

    public void HeroTakeDamageSound()
    {
        if (TryToMakeSound())
        {
            _audioSourceArray[6].Play();
        }
    }

    public void HealBoostSound()
    {
        if (TryToMakeSound())
        {
            _audioSourceArray[7].Play();
        }
    }
}
