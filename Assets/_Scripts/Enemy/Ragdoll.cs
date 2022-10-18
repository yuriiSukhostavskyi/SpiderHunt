using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ragdoll : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private Collider[] _colliders;

    public void Explosion(Vector3 position)
    {
        _rigidbody.AddExplosionForce(9000, position - Vector3.up * 1.5f, 200);
        Vector3 random = new Vector3(Random.Range(-180, 180), Random.Range(-180, 180), Random.Range(-180, 180));
        _rigidbody.angularVelocity = random;

        Invoke(nameof(DisableColliders), 5f);
        Destroy(gameObject, 6f);
    }

    private void DisableColliders()
    {
        for (int i = 0; i < _colliders.Length; i++)
        {
            _colliders[i].enabled = false;
        }
    }
}
