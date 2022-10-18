using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageTrigger : MonoBehaviour
{
    [SerializeField] private DamageTriggerSettings _damageTriggerSettings;

    private Gun _gun;
    private float _damage;

    private void OnEnable()
    {
        _damage = _damageTriggerSettings.Damage;
    }

    public void SetGun(Gun gun)
    {
        _gun = gun;
        Destroy(gameObject, 0.05f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Barrel barrel))
        {
            barrel.Explosion(transform.position, _gun);
        }

        if (other.TryGetComponent(out EnemyDieAction enemyDieAction))
        {
            enemyDieAction.TakeDamage(_damage, _gun);
        }

        if (other.TryGetComponent(out TurretDieAction turretDieAction))
        {
            turretDieAction.TakeDamage(_damage, _gun);
        }

        if (other.TryGetComponent(out HeroDieAction heroDieAction))
        {
            heroDieAction.TakeDamage(_damage, transform.position);
        }

        if (other.TryGetComponent(out WhiteCube whiteCube))
        {
            whiteCube.PublicRigidbody.AddExplosionForce(100, transform.position - Vector3.up * 3, 10);
        }
    }
}
