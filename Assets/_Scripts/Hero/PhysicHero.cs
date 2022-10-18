using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicHero : MonoBehaviour
{
    [SerializeField] private HeroDieAction _heroDieAction;

    public HeroDieAction PublicHeroDieAction => _heroDieAction;
}
