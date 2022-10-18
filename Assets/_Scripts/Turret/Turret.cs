using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Turret : MonoBehaviour
{

    private PhysicHeroMover _physicHeroMover;
    public PhysicHeroMover PublicPhysicHeroMover => _physicHeroMover;

    public void ActivateTurret(PhysicHeroMover physicHeroMover)
    {
        _physicHeroMover = physicHeroMover;
    }
}
