using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Barrel : MonoBehaviour
{
    [SerializeField] private GameObject _explosion;
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private DamageTrigger _explosionTrigger;
    [SerializeField] private EnemyBullet _enemyBullet;
    [SerializeField] private GameObject[] _shootPoint;

    private Gun _gun;
    private bool _startExplosion;

    public void Explosion(Vector3 position, Gun gun)
    {
        

        if (_startExplosion == false)
        {
            _startExplosion = true;
            _gun = gun;

            transform.DOKill(true);
            transform.DOShakeScale(0.6f, 0.9f, 15, 90, true);

            //_rigidbody.AddExplosionForce(1500, _gun.transform.position - Vector3.up / 5, 20);

            Invoke(nameof(ExplosionAction), 0.5f);
        }
        
    }

    private void ExplosionAction()
    {
        _gun.DecreaseBarrel(this);

        Instantiate(_explosion, transform.position, Quaternion.identity);
        DamageTrigger newExplosionTrigger = Instantiate(_explosionTrigger, transform.position, Quaternion.identity);
        newExplosionTrigger.SetGun(_gun);

        for (int i = 0; i < _shootPoint.Length; i++)
        {
            EnemyBullet newTurretBullet = Instantiate(_enemyBullet, _shootPoint[i].transform.position, _shootPoint[i].transform.rotation, transform.parent);
            newTurretBullet.SetGun(_gun);
        }

        Sound.Instance.ExplosionSound();
        Vibration.Instance.BigVibrate();
        Shake.Instance.ShakeAction();
        //TimeScaler.Instance.TimeScaleAction();

        gameObject.SetActive(false);
    }
}
