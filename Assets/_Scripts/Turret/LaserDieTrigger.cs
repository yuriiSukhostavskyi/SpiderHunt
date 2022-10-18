using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserDieTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out HeroDieAction heroDieAction))
        {
            heroDieAction.TakeDamage(25, transform.position);
        }
    }
}
