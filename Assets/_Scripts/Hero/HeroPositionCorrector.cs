using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroPositionCorrector : MonoBehaviour
{   
    [SerializeField] private PhysicHeroMover _physicHeroMover;
    [SerializeField] private Rigidbody _rigidbody;

    private float _breathPositionY = 0;
    private int _time = 0;

    private int _layermask = 1 << 6; //Platform
    private Ray _ray;
    private RaycastHit _hit;

    private void FixedUpdate()
    {
        if (_rigidbody.velocity.magnitude < 6)
        {
            _time++;

            if (_time < 40)
            {
                _breathPositionY += 0.005f; ;
            }

            if (_time >= 40)
            {
                _breathPositionY -= 0.005f;
            }

            if (_time == 78)
            {
                _time = 0;
            }
        }

        else if (_rigidbody.velocity.magnitude > 6)
        {
            _breathPositionY = 0;
            _time = 0;
        }
    }

    private void Update()
    {
            transform.position = _physicHeroMover.transform.position - Vector3.up * 0.25f + Vector3.up * _breathPositionY;
    }
}
