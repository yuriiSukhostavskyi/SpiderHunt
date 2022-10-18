using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeHead : MonoBehaviour
{
    [SerializeField] private SnakePoint[] _point;
    [SerializeField] private HeroTrigger _heroTrigger;

    private int _pointNumber = 0;

    private Vector3 _newDirection;
    private float _speed = 5.5f;
    private float _timeToStart = 2.15f;
    private float _time;
    private bool _goToHero;

    private void FixedUpdate()
    {
        _time += Time.fixedDeltaTime;

        if (_time > _timeToStart)
        {
            if (_goToHero == false)
            {
                _newDirection = _point[_pointNumber].transform.position - transform.position;
            }
            if (_goToHero == true)
            {
                _newDirection = _heroTrigger.PublicPhysicHeroMover.transform.position - transform.position;
            }

            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(_newDirection), 0.05f);

            transform.position += (transform.rotation * Vector3.forward * _speed) / 25 * Time.fixedDeltaTime * 50;
        }

        if (Random.Range(0.01f, 1.00f) < 0.05)
        {
            _pointNumber = Random.Range(0, _point.Length - 1);
            _goToHero = false;
        }
        if (Random.Range(0.01f, 1.00f) > 0.95 && _heroTrigger.VisibleHero != null)
        {
            _goToHero = true;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.TryGetComponent(out SnakePoint point) && _point[_pointNumber] == point)
        {
            _pointNumber = Random.Range(0, _point.Length - 1);
        }
    }
}
