using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private GameObject _hitVFX;
    [SerializeField] private DamageTrigger _explosionTrigger;

    private float _speed = 12; // вивести в скріптебл обджект
    private PhysicHeroMover _hero;
    private Gun _gun;

    private void OnEnable()
    {
        Invoke(nameof(Explosion), 3);
    }

    public void SetHero(PhysicHeroMover hero)
    {
        _hero = hero;
    }

    public void SetGun(Gun gun)
    {
        _gun = gun;
    }

    private void FixedUpdate()
    {
        _rigidbody.velocity = transform.forward * _speed;

        transform.rotation = Quaternion.Lerp(transform.rotation,
        Quaternion.LookRotation(new Vector3(_hero.transform.position.x, 0, _hero.transform.position.z) -
        new Vector3(transform.position.x, 0, transform.position.z), Vector3.up),
        0.06f); //вивести в скріптебл обджект
    }

    private void OnTriggerEnter(Collider other)
    {
        Explosion();
    }

    private void Explosion()
    {
        Sound.Instance.ExplosionSound();
        Vibration.Instance.BigVibrate();

        Instantiate(_hitVFX, transform.position, transform.rotation);
        DamageTrigger newExplosionTrigger = Instantiate(_explosionTrigger, transform.position, transform.rotation);
        newExplosionTrigger.SetGun(_gun);

        Destroy(gameObject);
    }
}
