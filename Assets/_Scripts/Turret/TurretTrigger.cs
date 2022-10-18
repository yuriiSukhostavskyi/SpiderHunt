using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretTrigger : MonoBehaviour
{
    [SerializeField] private Turret _turret;

    private PhysicHeroMover _physicHeroMover;
    private PhysicHeroMover _visibleHero;

    private int _layermask = 1 << 6 | 1 << 7 | 1 << 9; //Platform, Obstacle & hero
    private Ray _ray;
    private RaycastHit _hit;

    private float _time;

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
                _ray = new Ray(transform.position + Vector3.up * 0.3f, _physicHeroMover.transform.position - (transform.position + Vector3.up * 0.3f));
                if (Physics.Raycast(_ray.origin, _ray.direction, out _hit, 30, _layermask, QueryTriggerInteraction.Ignore))
                {
                    if (_hit.collider.TryGetComponent(out PhysicHeroMover physicHeroMover))
                    {
                        _visibleHero = _physicHeroMover;

                        _turret.ActivateTurret(_physicHeroMover);

                        Destroy(this);
                    }
                }
            }
        }
    }
}
