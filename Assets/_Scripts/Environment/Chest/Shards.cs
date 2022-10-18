using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shards : MonoBehaviour
{
    [SerializeField] private Renderer[] _shardsRenderer;
    [SerializeField] private Rigidbody[] _shardsRigidbody;
    [SerializeField] private Collider[] _shardsCollider;

    private Vector3 _hitPosition;
    private float _time;

    public void AddRandomExplosion(Vector3 position)
    {
        _hitPosition = position;

        for (int i = 0; i < _shardsRigidbody.Length; i++)
        {
            float force = Random.Range(80, 120);
            _shardsRigidbody[i].AddExplosionForce(force, _hitPosition - Vector3.up * 2 + Vector3.right * Random.Range(-0.5f, 0.5f) + Vector3.forward * Random.Range(-0.5f, 0.5f), 50);
        }
    }

    private void FixedUpdate()
    {
        _time += Time.fixedDeltaTime;

        if (_time > 6)
        {
            for (int i = 0; i < _shardsCollider.Length; i++)
            {
                _shardsCollider[i].enabled = false;
            }
        }

        if (_time > 9)
        {
            Destroy(gameObject);
        }
    }
}
