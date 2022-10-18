using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrailScaler : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private ParticleSystem _smokeTrail;
    [SerializeField] private PhysicHeroMover _physicHeroMover;

    private ParticleSystem.MainModule _psSmoke;
    private ParticleSystem.MainModule _psWater;

    private void OnEnable()
    {
        _psSmoke = _smokeTrail.main;
    }

    private void FixedUpdate()
    {
        ScaleTrail();
    }

    private void ScaleTrail()
    {
        if (_rigidbody.velocity.magnitude > 0.1 && _physicHeroMover.Grounded() == true)
        {
            _psSmoke.startLifetime = 2f;
        }
        if (_rigidbody.velocity.magnitude < 0.1 || _physicHeroMover.Grounded() == false)
        {
            _psSmoke.startLifetime = 0f;
        }
    }
}
