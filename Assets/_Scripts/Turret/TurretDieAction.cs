using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class TurretDieAction : MonoBehaviour
{
    [SerializeField] private HealBoost _healBoost;
    [SerializeField] private bool _giveHealBoost;
    [SerializeField] private TurretSettings _turretSettings;
    private float _health;
    [SerializeField] private Shards _shards;
    [SerializeField] private Silver _silver;
    private int _silverCount;
    [SerializeField] private Turret _turret;
    [SerializeField] private GameObject _explosion;
    [SerializeField] private GameObject _decal;
    [SerializeField] private MeshRenderer[] _meshRenderer;
    [SerializeField] private Material _whiteMaterial;
    [SerializeField] private HPBar _hpBar;
    [SerializeField] private GameObject _body;

    private Material[] _mainMaterial;

    private void OnEnable()
    {
        _health = _turretSettings.Health;
        _silverCount = _turretSettings.SilverCount;

        _mainMaterial = new Material[_meshRenderer.Length];

        for (int i = 0; i < _meshRenderer.Length; i++)
        {
            _mainMaterial[i] = _meshRenderer[i].material;
        }
    }

    public void TakeDamage(float damage, Gun gun)
    {
        ChangeMaterial();

        _health -= damage;

        _body.transform.DOShakeScale(0.2f, 0.4f, 15, 90, true);

        _hpBar.UpdateHPBar(_health, _turretSettings.Health, damage);

        if (_health <= 0)
        {
            Die(gun);
        }
    }

    private void ChangeMaterial()
    {
        for (int i = 0; i < _meshRenderer.Length; i++)
        {
            _meshRenderer[i].material = _whiteMaterial;
        }
        Invoke(nameof(ResetMaterial), 0.1f);
    }

    private void ResetMaterial()
    {
        for (int i = 0; i < _meshRenderer.Length; i++)
        {
            _meshRenderer[i].material = _mainMaterial[i];
        }
    }

    private void Die(Gun gun)
    {
        gun.DecreaseTurret(_turret);

        if (_giveHealBoost == true)
        {
            Instantiate(_healBoost, transform.position + Vector3.up * 1.5f, transform.rotation, transform.parent);
        }

        for (int i = 0; i < _silverCount; i++)
        {
            Vector3 random = new Vector3(Random.Range(-0.2f, 0.2f), 1, Random.Range(-0.2f, 0.2f));
            Silver newSilver = Instantiate(_silver, transform.position + random, transform.rotation, transform.parent);
            newSilver.SetExplosionForce();
            newSilver.SetHero(_turret.PublicPhysicHeroMover.PublicHero);
        }

        Sound.Instance.ExplosionSound();
        Vibration.Instance.BigVibrate();
        Shake.Instance.ShakeAction();

        Instantiate(_explosion, transform.position, transform.rotation);
        Instantiate(_decal, transform.position + Vector3.up * 0.1f, Quaternion.Euler(-90, 0, 0), transform.parent);
        //Shards newShards = Instantiate(_shards, transform.position + Vector3.up * 0.75f, transform.rotation, transform.parent);
        //newShards.AddRandomExplosion(transform.position);

        gameObject.SetActive(false);
    }
}
