using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlatform : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private Collider _trigger;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out PhysicHero _))
        {
            Invoke(nameof(Fall), 0.1f);
        }
        if (other.TryGetComponent(out FallingPlatform _fallingPlatform))
        {
            _fallingPlatform.StartFall();
        }
    }

    public void StartFall()
    {
        Invoke(nameof(Fall), 0.2f);
    }

    private void Fall()
    {
        _rigidbody.isKinematic = false;
        _trigger.enabled = true;
    }
}
