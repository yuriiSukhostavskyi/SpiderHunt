using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private HeroTrigger _heroTrigger;
    public HeroTrigger HeroTriggerObject => _heroTrigger;
}
