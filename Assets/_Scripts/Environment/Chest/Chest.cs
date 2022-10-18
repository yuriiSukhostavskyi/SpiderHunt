using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Chest : MonoBehaviour
{
    [SerializeField] private Silver _silver;
    [SerializeField] private GameObject _explosion;
    [SerializeField] private Shards _chestShards;
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private GameObject _decal;

    private int _silverCount = 10;
    private Gun _gun;

    public void GiveSilver(Gun gun)
    {
        _gun = gun;

        Quaternion random = Quaternion.Euler(0, Random.Range(-180, 180), 0);
        Silver newSilver = Instantiate(_silver, transform.position + Vector3.up, random, transform.parent);
        newSilver.SetExplosionForce();

        _rigidbody.AddExplosionForce(5000, gun.transform.position, 100);

        transform.DOKill(true);

        transform.localScale = new Vector3(1f, 1f, 1f);
        transform.DOShakeScale(0.2f, 0.4f, 15, 90, true);

        _silverCount--;

        if (_silverCount <= 0)
        {
            Explosion(gun);
        }
    }

    private void FixedUpdate()
    {
        if (transform.position.y < -0.5f)
        {
            Explosion(_gun);
        }
    }

    private void Explosion(Gun gun)
    {
        Instantiate(_explosion, transform.position, transform.rotation);
        Instantiate(_decal, transform.position + Vector3.up * 0.3f, Quaternion.Euler(-90, 0, 0));

        Shards newChestShards = Instantiate(_chestShards, transform.position + Vector3.up * 0.5f, transform.rotation);
        newChestShards.AddRandomExplosion(transform.position - Vector3.up);

        Sound.Instance.ExplosionSound();
        Vibration.Instance.BigVibrate();

        gun.DecreaseChest(this);
        Destroy(gameObject);
    }
}
