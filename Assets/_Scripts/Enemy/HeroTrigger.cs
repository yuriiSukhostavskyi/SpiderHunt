using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroTrigger : MonoBehaviour
{
    [SerializeField] private EnemyMover _enemyMover;
    [SerializeField] private JellyMover _jellyMover;
    [SerializeField] private Eye _eye;

    private int _layermask = 1 << 6 | 1 << 7 | 1 << 9; //Platform, Obstacle & hero
    private Ray _ray;
    private RaycastHit _hit;

    private PhysicHeroMover _physicHeroMover;
    private PhysicHeroMover _visibleHero;
    private float _time;

    public PhysicHeroMover PublicPhysicHeroMover => _physicHeroMover;
    public PhysicHeroMover VisibleHero => _visibleHero;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out PhysicHeroMover physicHeroMover))
        {
            _physicHeroMover = physicHeroMover;
        }
    }

    private void FixedUpdate()
    {
        _time += Time.fixedDeltaTime;

        if (_time > 2)
        {
            if (_physicHeroMover != null && _visibleHero == null)
            {
                _ray = new Ray(transform.position, _physicHeroMover.transform.position - transform.position);
                if (Physics.Raycast(_ray.origin, _ray.direction, out _hit, 30, _layermask, QueryTriggerInteraction.Ignore))
                {
                    if (_hit.collider.TryGetComponent(out PhysicHeroMover physicHeroMover))
                    {
                        Alarm(physicHeroMover);
                    }
                }
            }
        }
    }

    public void Alarm(PhysicHeroMover physicHeroMover)
    {
        if (physicHeroMover.gameObject.activeSelf == true)
        {
            _visibleHero = physicHeroMover;
            if (_enemyMover != null)
            {
                _enemyMover.SetHeroTarget(physicHeroMover);
            }
            if (_jellyMover != null)
            {
                _jellyMover.CanMove(_visibleHero);
            }
            if (_eye != null)
            {
                _eye.SetHero(_visibleHero);
            }
        }
        
        gameObject.SetActive(false);
    }
}
