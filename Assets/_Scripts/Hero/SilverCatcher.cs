using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SilverCatcher : MonoBehaviour
{
    [SerializeField] private Hero _hero;

    private void OnTriggerStay(Collider other)
    {
        if (other.TryGetComponent(out Silver silver))
        {
            silver.SetHero(_hero);
            silver.SetExplosionForceStandAlone();
        }
    }
}
