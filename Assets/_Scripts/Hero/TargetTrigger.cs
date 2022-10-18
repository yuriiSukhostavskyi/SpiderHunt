using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetTrigger : MonoBehaviour
{
    [SerializeField] private Gun _gun;

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.TryGetComponent(out Chest chest))
        {
            _gun.AddChest(chest);
        }
        if (other.TryGetComponent(out Enemy enemy))
        {
            _gun.AddEnemy(enemy);
        }
        if (other.TryGetComponent(out Barrel barrel))
        {
            _gun.AddBarrel(barrel);
        }
        if (other.TryGetComponent(out Turret turret))
        {
            _gun.AddTurret(turret);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out Chest chest))
        {
            _gun.DecreaseChest(chest);
        }
        if (other.TryGetComponent(out Enemy enemy))
        {
            _gun.DecreaseEnemy(enemy);
        }
        if (other.TryGetComponent(out Barrel barrel))
        {
            _gun.DecreaseBarrel(barrel);
        }
        if (other.TryGetComponent(out Turret turret))
        {
            _gun.DecreaseTurret(turret);
        }
    }


}
