using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TailDieAction : MonoBehaviour
{
    [SerializeField] private SnakeDieAction _snakeDieAction;
    public void TakeDamage(float damage, Gun gun)
    {
        _snakeDieAction.TakeDamage(damage, gun);
    }
}
