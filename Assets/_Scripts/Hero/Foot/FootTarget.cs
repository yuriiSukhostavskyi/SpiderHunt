using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootTarget : MonoBehaviour
{
    [SerializeField] private GameObject _outsideFootTarget;

    private void Update()
    {
        transform.position += (_outsideFootTarget.transform.position - transform.position) / 6;
    }
}
