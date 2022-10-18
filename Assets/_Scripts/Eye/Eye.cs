using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eye : MonoBehaviour
{
    private PhysicHeroMover _hero;

    public void SetHero(PhysicHeroMover hero)
    {
        _hero = hero;
    }

    private void FixedUpdate()
    {
        if (_hero != null)
        {
            transform.rotation = Quaternion.LookRotation(_hero.transform.position - transform.position);
        }
    }
}
