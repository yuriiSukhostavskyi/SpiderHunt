using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    [SerializeField] private Gun _gun;
    [SerializeField] private HeroPositionCorrector _heroMover;
    [SerializeField] private GameObject _shootPoint;
    [SerializeField] private Bullet _bullet;
    [SerializeField] private ParticleSystem _shootVFX;
    [SerializeField] private GameObject _muzzle;
    [SerializeField] private Rigidbody _rigidbody;

    private float _shootTime;
    private float _time = 0;

    private Vector3 _transformStartPosition;
    private Vector3 _muzzleTransformStartPosition;

    private void OnEnable()
    {
        _shootTime = Saves.Get.GetFloat(Keys.Rate);
        _transformStartPosition = transform.localPosition;
        _muzzleTransformStartPosition = _muzzle.transform.localPosition;
    }

    private void Update()
    {
        transform.localPosition = new Vector3(transform.localPosition.x * 0.92f, 0.5f, transform.localPosition.z * 0.92f);
        _muzzle.transform.localPosition = new Vector3(_muzzle.transform.localPosition.x * 0.92f, 0f, _muzzle.transform.localPosition.z * 0.912f);

        if (_gun.Target != null && _rigidbody.velocity.magnitude < 6)
        {
            _time += Time.deltaTime;
        }

        if (_time > _shootTime)
        {
            _time = 0;
            ShootAction();
        }
    }
    public void ShootAction()
    {
        Quaternion random = Quaternion.Euler(Random.Range(-3.5f, 3.5f), Random.Range(-3.5f, 3.5f), Random.Range(-3.5f, 3.5f));
        Bullet newBullet = Instantiate(_bullet, _shootPoint.transform.position, transform.rotation * random);
        newBullet.SetGun(_gun);

        _shootVFX.Play();

        Sound.Instance.ShootSound();
        Vibration.Instance.ShortVibrate();

        transform.localPosition = _transformStartPosition - transform.forward * 0.3f;  //new Vector3(transform.localPosition.x, transform.localPosition.y, -0.175f);
        _muzzle.transform.localPosition = new Vector3(0, 0, -0.55f); //new Vector3(_muzzle.transform.localPosition.x, _muzzle.transform.localPosition.y, - 0.35f);
    }
}
