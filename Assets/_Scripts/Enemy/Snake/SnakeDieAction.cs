using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class SnakeDieAction : MonoBehaviour
{
    [SerializeField] private SnakeData _snakeData;
    [SerializeField] private Enemy _enemy;
    [SerializeField] private Silver _silver;
    [SerializeField] private GameObject _explosion;
    [SerializeField] private GameObject _decal;
    [SerializeField] private HPBar _hpBar;
    [SerializeField] private MeshRenderer[] _meshRenderer;
    [SerializeField] private GameObject _body;
    [SerializeField] private Tail[] _tail;
    [SerializeField] private Material _whiteMaterial;

    private bool _die = false;
    private int _silverCount;
    private float _health;
    private Material[] _mainMaterial;

    private void OnEnable()
    {
        _health = _snakeData.Health;
        _silverCount = _snakeData.SilverCount;

        _mainMaterial = new Material[_meshRenderer.Length];

        for (int i = 0; i < _meshRenderer.Length; i++)
        {
            _mainMaterial[i] = _meshRenderer[i].material;
        }
    }

    public void TakeDamage(float damage, Gun gun)
    {
        

        _health -= damage;

        _hpBar.UpdateHPBar(_health, _snakeData.Health, damage);

        if (_health <= 0)
        {
            Die(gun);
        }

        ChangeMaterial();

        _body.transform.DOKill(true);
        _body.transform.DOShakeScale(0.2f, 0.4f, 15, 90, true);
    }

    private void ChangeMaterial()
    {
        for (int i = 0; i < _meshRenderer.Length; i++)
        {
            if (_meshRenderer[i] != null)
            {
                _meshRenderer[i].material = _whiteMaterial;
            }
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
        if (_die == false)
        {
            gun.DecreaseEnemy(_enemy);
            _die = true;

            for (int i = 0; i < _silverCount; i++)
            {
                Vector3 random = new Vector3(Random.Range(-0.2f, 0.2f), 1, Random.Range(-0.2f, 0.2f));
                Silver newSilver = Instantiate(_silver, transform.position + random, transform.rotation, transform.parent);
                newSilver.SetExplosionForce();
                newSilver.SetHero(_enemy.HeroTriggerObject.PublicPhysicHeroMover.PublicHero);
            }

            Instantiate(_explosion, transform.position + Vector3.up * 0.5f, Quaternion.identity);
            Instantiate(_decal, transform.position + Vector3.up * 0.1f, Quaternion.Euler(-90, 0, 0), transform.parent);

            Sound.Instance.ExplosionSound();
            Vibration.Instance.BigVibrate();
            Shake.Instance.ShakeAction();

            for (int i = 0; i < _tail.Length; i++)
            {
                gun.DecreaseEnemy(_tail[i].PublicEnemy);

                Instantiate(_explosion, _tail[i].transform.position + Vector3.up * 0.5f, Quaternion.identity);
                Instantiate(_decal, _tail[i].transform.position + Vector3.up * 0.1f, Quaternion.Euler(-90, 0, 0), transform.parent);

                _tail[i].gameObject.SetActive(false);
            }

            gameObject.SetActive(false);
        }
    }
}
