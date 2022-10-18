using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretTurn : MonoBehaviour
{
    [SerializeField] private Turret _turret;
    [SerializeField] private GameObject _tower;

    private void OnEnable()
    {
        _tower.transform.rotation = Quaternion.Euler(0, Random.Range(-180,180), 0);
    }

    private void FixedUpdate()
    {
        if (_turret.PublicPhysicHeroMover != null)
        {
            _tower.transform.rotation = Quaternion.Lerp(_tower.transform.rotation,
                Quaternion.LookRotation(new Vector3(_turret.PublicPhysicHeroMover.transform.position.x, 0, _turret.PublicPhysicHeroMover.transform.position.z) -
                new Vector3(transform.position.x, 0, transform.position.z), Vector3.up),
                0.05f);
        }   
    }
}
