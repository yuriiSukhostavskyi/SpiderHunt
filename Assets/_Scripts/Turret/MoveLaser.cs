using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MoveLaser : MonoBehaviour
{
    [SerializeField] private GameObject[] _point;
    [SerializeField] private float _speed;

    private int _pointNumber = 0;
    private float _waitTime = 0.85f;
    private float _movingTime;

    private float _time = -0.65f;
    private bool _move = true;

    private void OnEnable()
    {
        if (_point.Length > 0)
        {
            SetMovingTime();
        }
    }

    private void SetMovingTime()
    {
        _movingTime = Vector3.Distance(_point[_pointNumber].transform.position, transform.position) / _speed;
    }

    private void FixedUpdate()
    {
        _time += Time.fixedDeltaTime;

        if (_point.Length > 0 && _time > _movingTime + _waitTime)
        {
            SetMovingTime();
            transform.DOMove(_point[_pointNumber].transform.position, _movingTime);

            _time = 0;

            _pointNumber++;
            if (_pointNumber > _point.Length - 1)
            {
                _pointNumber = 0;
            }
        }
    }
}
