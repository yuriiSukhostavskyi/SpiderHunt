using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealBoost : MonoBehaviour
{
    [SerializeField] private GameObject _healVFX;

    private float _angleY;
    private float _healPower = 50;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out HeroDieAction heroDieAction))
        {

            heroDieAction.TakeHeal(_healPower);

            Instantiate(_healVFX, transform.position, transform.rotation * Quaternion.Euler(90, 0, 0), transform.parent);

            Destroy(gameObject);
        }
    }

    private void FixedUpdate()
    {
        _angleY += 5;
        transform.rotation = Quaternion.Euler(0, _angleY, 0);
    }
}
