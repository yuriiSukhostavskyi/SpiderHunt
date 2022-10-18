using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossShards : MonoBehaviour
{
    private Rigidbody _rigidbody;
    private Collider _collider;

    private bool _explosion = false;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _collider = GetComponent<Collider>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Bullet bullet))
        {
            Explosion();
        }
    }

    public void Explosion()
    {
        if (_explosion == false)
        {
            _explosion = true;

            _rigidbody.isKinematic = false;
            _collider.isTrigger = false;

            _rigidbody.interpolation = RigidbodyInterpolation.Interpolate;

            transform.parent = transform.parent.parent.parent.parent;

            Vector3 random = new Vector3(Random.Range(-0.5f, 0.5f), 0, Random.Range(-0.5f, 0.5f));
            _rigidbody.AddExplosionForce(1200, transform.position + random - Vector3.up / 2, 50);
        }
        
    }
}
