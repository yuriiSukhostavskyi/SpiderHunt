using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Silver : MonoBehaviour
{
    [SerializeField] private GameObject _vfxSilver;
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private TrailRenderer _trail;

    public delegate void OnSilverCatchDelegate();
    public static event OnSilverCatchDelegate OnSilverCatch;

    private Hero _hero;
    private bool _goToHero = false;
    private float _speed = 35;
    private float _cooldown = 0;

    private void OnEnable()
    {
        FinishAction.OnFinished += UnSetHero;
    }

    private void UnSetHero()
    {
        _goToHero = false;
        _hero = null;
    }

    public void SetHero(Hero hero)
    {
        if (_hero == null)
        {
            _rigidbody.interpolation = RigidbodyInterpolation.Interpolate;
            _hero = hero;
            Invoke(nameof(CanGoToHero), 0.3f);
            _trail.enabled = true;
        }
    }

    public void SetExplosionForce()
    {
        _rigidbody.isKinematic = false;

        Vector3 random = new Vector3(Random.Range(-0.6f, 0.6f), -0.6f, Random.Range(-0.6f, 0.6f));
        _rigidbody.AddExplosionForce(14, transform.position + random, 50);
        transform.rotation = Quaternion.LookRotation(-random) * Quaternion.Euler(0, 90, 0);
        //_rigidbody.angularVelocity = new Vector3(Random.Range(-200, 200), Random.Range(-200, 200), Random.Range(-200, 200));
    }

    public void SetExplosionForceStandAlone()
    {
        _rigidbody.isKinematic = false;

        if (_goToHero == false)
        {
            _rigidbody.AddExplosionForce(4, _hero.transform.position - Vector3.up / 0.5f, 50);
            transform.rotation = Quaternion.LookRotation(_hero.transform.position - transform.position) * Quaternion.Euler(0, 90, 0);
            _cooldown = 0.3f;
        }
    }

    private void CanGoToHero()
    {
        if (_hero != null)
        {
            _goToHero = true;
        }
    }

    private void FixedUpdate()
    {
        _cooldown += Time.fixedDeltaTime;

        if (_cooldown < 0.8f)
        {
            _rigidbody.velocity /= 1.06f;
        }

        if (_goToHero == true && _cooldown > 0.8f && _hero != null)
        {
            transform.rotation = Quaternion.LookRotation(_hero.transform.position - transform.position);
            _rigidbody.velocity = transform.forward * _speed;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out PhysicHeroMover _) && _goToHero == true)
        {
            if (OnSilverCatch != null)
            {
                OnSilverCatch();
            }

            Instantiate(_vfxSilver, transform.position, Quaternion.identity);

            Sound.Instance.SilverSound();
            Vibration.Instance.ShortVibrate();

            /*_hero.transform.DOKill(true);

            _hero.transform.localScale = new Vector3(1f, 1f, 1f);
            _hero.transform.DOShakeScale(0.2f, 0.4f, 15, 90, true);*/

            gameObject.SetActive(false);
        }
    }
}
