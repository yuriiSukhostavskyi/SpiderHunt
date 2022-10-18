using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionAfterJump : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private GameObject _vfx;

    private float _prevY;
    private float _currentY;

    private void FixedUpdate()
    {
        _currentY = _rigidbody.velocity.y;

        if (_currentY - _prevY > 5)
        {
            Instantiate(_vfx, transform.position - Vector3.up * 0.25f, Quaternion.Euler(-90, 0, 0));

            Sound.Instance.WallSound();
            Vibration.Instance.ShortVibrate();
            Shake.Instance.ShakeAction();
        }

        _prevY = _currentY;
    }
}
