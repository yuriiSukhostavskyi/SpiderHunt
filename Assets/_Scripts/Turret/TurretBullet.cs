using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretBullet : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private GameObject _hitVFX;
    [SerializeField] private DamageTrigger _damageTrigger;

    private float _speed = 8;
    private Vector3 _turretPosition;
    private Gun _gun;

    private void OnEnable()
    {
        _rigidbody.velocity = transform.forward * _speed;
        Destroy(gameObject, 15f);
    }

    public void SetTurretPosition(Vector3 position)
    {
        //_turretPosition = position;
    }

    public void SetGun(Gun gun)
    {
        _gun = gun;
    }

    private void OnTriggerEnter(Collider other)
    {
        /*if (other.TryGetComponent(out HeroDieAction heroDieAction))
        {
            heroDieAction.TakeDamage(15, other.transform.position - transform.forward);
        }

        if (other.TryGetComponent(out Bullet bullet))
        {
            
        }*/

        //if (other.TryGetComponent(out EnemyDieAction enemyDieAction))
        //{
        //enemyDieAction.Die(transform.position);
        //}

        DamageTrigger newExplosionTrigger = Instantiate(_damageTrigger, transform.position, transform.rotation);
        newExplosionTrigger.SetGun(_gun);

        Instantiate(_hitVFX, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
