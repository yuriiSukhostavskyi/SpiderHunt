using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private HeroSettings _heroSettings;
    [SerializeField] private GameObject _hitVFX;

    private float _speed;
    private float _damage;

    private Gun _gun;

    private void OnEnable()
    {
        _damage = Saves.Get.GetFloat(Keys.Damage);
        _speed = _heroSettings.BulletSpeed;
        Destroy(gameObject, 6f);
    }

    public void SetGun(Gun gun)
    {
        _gun = gun;
    }

    private void Update()
    {
        transform.position += transform.forward * _speed * Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out EnemyDieAction enemyDieAction))
        {
            enemyDieAction.TakeDamage(_damage, _gun);

            Instantiate(_hitVFX, transform.position, transform.rotation);
            DestroyBullet();
        }

        if (other.TryGetComponent(out Wall _))
        {
            Instantiate(_hitVFX, transform.position, transform.rotation);
            DestroyBullet();
        }

        if (other.TryGetComponent(out TurretBullet _))
        {
            Instantiate(_hitVFX, transform.position, transform.rotation);
            DestroyBullet();
        }

        if (other.TryGetComponent(out Chest chest))
        {
            chest.GiveSilver(_gun);

            Instantiate(_hitVFX, transform.position, transform.rotation);
            DestroyBullet();
        }

        if (other.TryGetComponent(out Barrel barrel))
        {
            barrel.Explosion(transform.position, _gun);

            Instantiate(_hitVFX, transform.position, transform.rotation);
            DestroyBullet();
        }

        if (other.TryGetComponent(out Platform platform))
        {
            Instantiate(_hitVFX, transform.position, transform.rotation);
            DestroyBullet();
        }

        if (other.TryGetComponent(out TurretDieAction turretDieAction))
        {
            turretDieAction.TakeDamage(_damage, _gun);

            Instantiate(_hitVFX, transform.position, transform.rotation);
            DestroyBullet();
        }

        if (other.TryGetComponent(out SnakeDieAction snakeDieAction))
        {
            snakeDieAction.TakeDamage(_damage, _gun);

            Instantiate(_hitVFX, transform.position, transform.rotation);
            DestroyBullet();
        }

        if (other.TryGetComponent(out TailDieAction tailDieAction))
        {
            tailDieAction.TakeDamage(_damage, _gun);

            Instantiate(_hitVFX, transform.position, transform.rotation);
            DestroyBullet();
        }

        if (other.TryGetComponent(out JellyDieAction jellyDieAction))
        {
            jellyDieAction.TakeDamage(_damage, _gun);

            Instantiate(_hitVFX, transform.position, transform.rotation);
            DestroyBullet();
        }

        if (other.TryGetComponent(out Shield _))
        {
            Quaternion newDirection = transform.rotation * Quaternion.Euler(0, Random.Range(150, 210), 0);
            transform.rotation = newDirection;
        }

    }

    private void DestroyBullet()
    {
        Destroy(gameObject);
    }
}
