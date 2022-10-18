using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackTrigger : MonoBehaviour
{

    private float _damage;

    public void SetDamage(float damage)
    {
        _damage = damage;
        Destroy(gameObject, 0.1f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out HeroDieAction heroDieAction))
        {
            heroDieAction.TakeDamage(_damage, transform.position);
        }
    }
}
