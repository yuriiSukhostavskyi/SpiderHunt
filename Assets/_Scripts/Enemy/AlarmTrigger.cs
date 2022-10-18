using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlarmTrigger : MonoBehaviour
{

    private int _layermask = 1 << 7 | 1 << 8; //Obstacle & Enemy
    private Ray _ray;
    private RaycastHit _hit;

    private PhysicHeroMover _physicHeroMover;

    public void SetHero(PhysicHeroMover physicHeroMover)
    {
        _physicHeroMover = physicHeroMover;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Enemy enemy) && _physicHeroMover != null)
        {
            _ray = new Ray(transform.position + Vector3.up * 0.2f, (enemy.transform.position - transform.position).normalized);
            if (Physics.SphereCast(_ray.origin, 0.2f, _ray.direction, out _hit, 30, _layermask, QueryTriggerInteraction.Ignore))
            {
                if (_hit.collider.TryGetComponent(out Enemy enemy_2) && enemy == enemy_2)
                {
                    enemy_2.HeroTriggerObject.Alarm(_physicHeroMover);
                }
            }
        }
    }
}
