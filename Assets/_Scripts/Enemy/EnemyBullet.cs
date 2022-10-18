using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    [SerializeField] private Rocket _rocket;
    [SerializeField] private TurretBullet _turretBullet;

    public void SetHero(PhysicHeroMover hero)
    {
        if (_rocket != null)
        {
            _rocket.SetHero(hero);
        }
    }

    public void SetGun(Gun gun)
    {
        if (_rocket != null)
        {
            _rocket.SetGun(gun);
        }

        if (_turretBullet != null)
        {
            _turretBullet.SetGun(gun);
        }
    }
}
