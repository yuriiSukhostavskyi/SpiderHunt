using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserTwoObject : MonoBehaviour
{
    [SerializeField] private LineRenderer _lineRenderer;
    [SerializeField] private Collider _collider;
    [SerializeField] private GameObject _enemyCount_1;
    [SerializeField] private GameObject _enemyCount_2;

    [SerializeField] private bool _withTiming;

    private int _time;

    private void FixedUpdate()
    {
        if (_enemyCount_1.activeSelf == false || _enemyCount_2.activeSelf == false)
        {
            DestroyLaser();
        }

        WithTiming();
    }

    private void WithTiming()
    {
        if (_withTiming == true)
        {
            _time ++;

            if (_time == 75)
            {
                _lineRenderer.enabled = false;
                _collider.enabled = false;
            }

            if (_time == 150)
            {
                _lineRenderer.enabled = true;
                _collider.enabled = true;

                _time = 0;
            }
        }
    }

    private void DestroyLaser()
    {
        gameObject.SetActive(false);
    }
}
