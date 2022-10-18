using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretShoot : MonoBehaviour
{
    [SerializeField] private TurretSettings _turretSettings;
    [SerializeField] private EnemyBullet _turretBullet;
    [SerializeField] private GameObject _shootPoint;
    [SerializeField] private GameObject _shootVFX;
    [SerializeField] private GameObject _tower;
    [SerializeField] private Turret _turret;

    [SerializeField] private GameObject _muzzle;

    private float _progress;
    private float _progressSpeed;

    private void OnEnable()
    {
        _progress = 0.5f;

        _progressSpeed = _turretSettings.RateOfFire;
    }

    private void FixedUpdate()
    {
        if (_turret.PublicPhysicHeroMover != null && _turret.PublicPhysicHeroMover.gameObject.activeSelf == true)
        {
            _progress += _progressSpeed;
        }

        if (_progress > 1)
        {
            _progress = 0;
            Shoot();
        }
    }

    private void Shoot()
    {
        EnemyBullet newTurretBullet = Instantiate(_turretBullet, _shootPoint.transform.position, _shootPoint.transform.rotation, transform.parent);
        newTurretBullet.SetHero(_turret.PublicPhysicHeroMover);
        newTurretBullet.SetGun(_turret.PublicPhysicHeroMover.PublicGun);

        Instantiate(_shootVFX, _shootPoint.transform.position, _shootPoint.transform.rotation);
    }
}
