using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WatterSetter : MonoBehaviour
{
    [SerializeField] private Assets.Scripts.Water.WaterPropertyBlockSetter _water;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Renderer renderer))
        {
            _water.SetToWater(renderer);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out Renderer renderer))
        {
            _water.UnSetFromWater(renderer);
        }
    }
}
